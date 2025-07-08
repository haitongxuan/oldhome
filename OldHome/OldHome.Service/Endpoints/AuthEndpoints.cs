using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OldHome.DAL;
using OldHome.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OldHome.Service.Endpoints
{
    public static class AuthEndpoints
    {
        const string key = "L9vZfN4xW2q8RmX0jP7cT5sBqMd1KvUg";

        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/auth");

            // 登录
            app.MapPost("/login", async (AppDataContext db, SignInRequset login, HttpContext context) =>
            {
                var user = await db.Users.Include(p => p.Role).SingleOrDefaultAsync(u => u.UserName == login.UserName && u.OrgId == login.OrgId);

                // 验证用户名密码
                if (user != null && BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
                {
                    var jwtId = Guid.NewGuid().ToString();
                    var tokenResponse = GenerateTokens(user, jwtId);

                    // 保存 RefreshToken 到数据库
                    await SaveRefreshTokenAsync(db, user.Id, tokenResponse.RefreshToken!, jwtId,
                        context.Connection.RemoteIpAddress?.ToString(),
                        context.Request.Headers["User-Agent"].ToString());

                    return Results.Ok(tokenResponse);
                }

                return Results.Unauthorized();
            });

            // 刷新令牌
            group.MapPost("/refresh-token", async (AppDataContext db, RefreshTokenRequest request, HttpContext context) =>
            {
                try
                {
                    // 验证 RefreshToken
                    var principal = ValidateRefreshToken(request.RefreshToken);
                    if (principal == null)
                    {
                        return Results.Unauthorized();
                    }

                    var username = principal.FindFirst(ClaimTypes.Name)?.Value;
                    var userIdClaim = principal.FindFirst("user_id")?.Value;
                    var jwtId = principal.FindFirst("jti")?.Value;

                    if (string.IsNullOrEmpty(username) || !int.TryParse(userIdClaim, out int userId) || string.IsNullOrEmpty(jwtId))
                    {
                        return Results.Unauthorized();
                    }

                    // 检查令牌是否在数据库中有效
                    if (!await IsRefreshTokenValidAsync(db, userId, jwtId))
                    {
                        return Results.Unauthorized();
                    }

                    // 从数据库获取用户信息
                    var user = await db.Users.Include(p => p.Role)
                        .SingleOrDefaultAsync(u => u.Id == userId);

                    if (user == null)
                    {
                        return Results.Unauthorized();
                    }

                    // 生成新的令牌对
                    var newJwtId = Guid.NewGuid().ToString();
                    var tokenResponse = GenerateTokens(user, newJwtId);

                    // 更新数据库中的 RefreshToken
                    await UpdateRefreshTokenAsync(db, user.Id, jwtId, tokenResponse.RefreshToken!, newJwtId,
                        context.Connection.RemoteIpAddress?.ToString(),
                        context.Request.Headers["User-Agent"].ToString());

                    return Results.Ok(tokenResponse);
                }
                catch (SecurityTokenException)
                {
                    return Results.Unauthorized();
                }
                catch (Exception ex)
                {
                    return Results.Problem($"刷新令牌时发生错误: {ex.Message}");
                }
            });

            // 撤销令牌
            group.MapPost("/revoke-token", [Authorize] async (AppDataContext db, RevokeTokenRequest request, HttpContext context) =>
            {
                try
                {
                    var userIdClaim = context.User.FindFirst("user_id")?.Value;
                    if (!int.TryParse(userIdClaim, out int userId))
                    {
                        return Results.Unauthorized();
                    }

                    // 解析要撤销的令牌以获取 JWT ID
                    var principal = ValidateRefreshToken(request.RefreshToken);
                    var jwtId = principal?.FindFirst("jti")?.Value;

                    if (!string.IsNullOrEmpty(jwtId))
                    {
                        await RevokeRefreshTokenAsync(db, userId, jwtId, "用户手动撤销");
                    }

                    return Results.Ok(new { message = "令牌已成功撤销" });
                }
                catch (Exception ex)
                {
                    return Results.Problem($"撤销令牌时发生错误: {ex.Message}");
                }
            });

            // 登出
            group.MapPost("/logout", [Authorize] async (AppDataContext db, HttpContext context) =>
            {
                try
                {
                    var userIdClaim = context.User.FindFirst("user_id")?.Value;
                    if (!int.TryParse(userIdClaim, out int userId))
                    {
                        return Results.Unauthorized();
                    }

                    // 撤销用户的所有 RefreshToken
                    await RevokeAllRefreshTokensAsync(db, userId, "用户登出");

                    return Results.Ok(new { message = "已成功登出" });
                }
                catch (Exception ex)
                {
                    return Results.Problem($"登出时发生错误: {ex.Message}");
                }
            });

            // 受保护的数据端点
            app.MapGet("/secure-data", [Authorize] () =>
            {
                return Results.Ok("这是受保护的数据");
            });

            // 获取用户信息
            app.MapGet("/profile", [Authorize] async (AppDataContext db, HttpContext context) =>
            {
                var username = context.User.Identity?.Name;
                var user = await db.Users.SingleOrDefaultAsync(u => u.UserName == username);
                if (user == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    var profile = new ProfileResponse(user.UserName, user.CreatedAt, user.PhoneNum);
                    return Results.Ok(profile);
                }
            });
        }

        /// <summary>
        /// 生成访问令牌和刷新令牌
        /// </summary>
        private static SignInResponse GenerateTokens(Entities.User user, string jwtId)
        {
            // 生成访问令牌 (短期有效)
            var accessTokenClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.Code),
                new Claim("org_id", user.OrgId.ToString()),
                new Claim("user_id", user.Id.ToString()),
                new Claim("token_type", "access")
            };

            var accessToken = new JwtSecurityToken(
                claims: accessTokenClaims,
                expires: DateTime.UtcNow.AddHours(1), // 访问令牌1小时有效
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256)
            );

            // 生成刷新令牌 (长期有效)
            var refreshTokenClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("org_id", user.OrgId.ToString()),
                new Claim("user_id", user.Id.ToString()),
                new Claim("token_type", "refresh"),
                new Claim("jti", jwtId) // JWT ID，用于撤销
            };

            var refreshToken = new JwtSecurityToken(
                claims: refreshTokenClaims,
                expires: DateTime.UtcNow.AddDays(7), // 刷新令牌7天有效
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256)
            );

            var accessJwt = new JwtSecurityTokenHandler().WriteToken(accessToken);
            var refreshJwt = new JwtSecurityTokenHandler().WriteToken(refreshToken);

            return new SignInResponse(accessJwt, user.UserName, user.Role.Code, user.OrgId, refreshJwt);
        }

        /// <summary>
        /// 验证刷新令牌
        /// </summary>
        private static ClaimsPrincipal? ValidateRefreshToken(string refreshToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out var validatedToken);

                // 验证是否是刷新令牌
                var tokenTypeClaim = principal.FindFirst("token_type")?.Value;
                if (tokenTypeClaim != "refresh")
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 保存刷新令牌到数据库
        /// </summary>
        private static async Task SaveRefreshTokenAsync(AppDataContext db, int userId, string refreshToken, string jwtId, string? ipAddress = null, string? userAgent = null)
        {
            var tokenEntity = new Entities.RefreshToken
            {
                UserId = userId,
                OrgId = (await db.Users.FindAsync(userId))?.OrgId ?? 0,
                Token = refreshToken,
                JwtId = jwtId,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IpAddress = ipAddress,
                UserAgent = userAgent,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "system"
            };

            // 清理过期的令牌
            var expiredTokens = await db.RefreshTokens
                .Where(rt => rt.UserId == userId && rt.ExpiresAt < DateTime.UtcNow)
                .ToListAsync();

            if (expiredTokens.Any())
            {
                db.RefreshTokens.RemoveRange(expiredTokens);
            }

            // 限制每个用户最多保留10个活跃的刷新令牌
            var activeTokensCount = await db.RefreshTokens
                .Where(rt => rt.UserId == userId && !rt.IsRevoked && !rt.IsUsed)
                .CountAsync();

            if (activeTokensCount >= 10)
            {
                var oldestTokens = await db.RefreshTokens
                    .Where(rt => rt.UserId == userId && !rt.IsRevoked && !rt.IsUsed)
                    .OrderBy(rt => rt.CreatedAt)
                    .Take(activeTokensCount - 9)
                    .ToListAsync();

                foreach (var token in oldestTokens)
                {
                    token.IsRevoked = true;
                    token.RevokedAt = DateTime.UtcNow;
                    token.RevokeReason = "超出令牌数量限制";
                }
            }

            db.RefreshTokens.Add(tokenEntity);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// 检查刷新令牌是否在数据库中有效
        /// </summary>
        private static async Task<bool> IsRefreshTokenValidAsync(AppDataContext db, int userId, string jwtId)
        {
            var token = await db.RefreshTokens
                .SingleOrDefaultAsync(rt => rt.UserId == userId && rt.JwtId == jwtId);

            return token?.IsValid == true;
        }

        /// <summary>
        /// 标记旧令牌为已使用，并保存新令牌
        /// </summary>
        private static async Task UpdateRefreshTokenAsync(AppDataContext db, int userId, string oldJwtId, string newRefreshToken, string newJwtId, string? ipAddress = null, string? userAgent = null)
        {
            // 标记旧令牌为已使用
            var oldToken = await db.RefreshTokens
                .SingleOrDefaultAsync(rt => rt.UserId == userId && rt.JwtId == oldJwtId);

            if (oldToken != null)
            {
                oldToken.IsUsed = true;
                oldToken.UsedAt = DateTime.UtcNow;
                oldToken.UpdatedAt = DateTime.UtcNow;
                oldToken.UpdatedBy = "system";
            }

            // 保存新令牌
            await SaveRefreshTokenAsync(db, userId, newRefreshToken, newJwtId, ipAddress, userAgent);
        }

        /// <summary>
        /// 撤销特定的刷新令牌
        /// </summary>
        private static async Task RevokeRefreshTokenAsync(AppDataContext db, int userId, string jwtId, string reason = "用户请求撤销")
        {
            var token = await db.RefreshTokens
                .SingleOrDefaultAsync(rt => rt.UserId == userId && rt.JwtId == jwtId);

            if (token != null)
            {
                token.IsRevoked = true;
                token.RevokedAt = DateTime.UtcNow;
                token.RevokeReason = reason;
                token.UpdatedAt = DateTime.UtcNow;
                token.UpdatedBy = "system";

                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 撤销用户的所有刷新令牌
        /// </summary>
        private static async Task RevokeAllRefreshTokensAsync(AppDataContext db, int userId, string reason = "用户登出")
        {
            var tokens = await db.RefreshTokens
                .Where(rt => rt.UserId == userId && !rt.IsRevoked)
                .ToListAsync();

            foreach (var token in tokens)
            {
                token.IsRevoked = true;
                token.RevokedAt = DateTime.UtcNow;
                token.RevokeReason = reason;
                token.UpdatedAt = DateTime.UtcNow;
                token.UpdatedBy = "system";
            }

            if (tokens.Any())
            {
                await db.SaveChangesAsync();
            }
        }
    }
}