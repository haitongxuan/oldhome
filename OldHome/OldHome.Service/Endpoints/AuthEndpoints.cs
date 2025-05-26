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
            app.MapPost("/login", async (AppDataContext db, SignInRequset login) =>
            {
                var user = await db.Users.Include(p => p.Role).SingleOrDefaultAsync(u => u.UserName == login.UserName && u.OrgId == login.OrgId);
                // 模拟登录验证
                if (user != null && BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, login.UserName),
                        new Claim(ClaimTypes.Role, user.Role.Code),
                    };

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                            SecurityAlgorithms.HmacSha256)
                    );

                    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                    return Results.Ok(new SignInResponse(jwt, user.UserName, user.Role.Code, user.OrgId));
                }

                return Results.Unauthorized();
            });

            app.MapGet("/secure-data", [Authorize] () =>
            {
                return Results.Ok("这是受保护的数据");
            });

            // **获取用户信息**
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
    }
}
