using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using OldHome.API;
using OldHome.API.Services;
using OldHome.DTO;
using OldHome.Wasm.Services;
using System.Security.Claims;
using System.Text.Json;

namespace OldHome.Wasm
{
    public class AppAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IUserSessionService _userSession;
        private readonly IJSRuntime _jsRuntime;
        private readonly ApiClient _apiClient;

        private const string TOKEN_KEY = "authToken";
        private const string USER_KEY = "authUser";

        public AppAuthStateProvider(
          IUserSessionService userSession,
          IJSRuntime jsRuntime,
          ApiClient apiClient)
        {
            _userSession = userSession;
            _jsRuntime = jsRuntime;
            _apiClient = apiClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // 尝试从本地存储获取token
                var savedToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TOKEN_KEY);
                var savedUserJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", USER_KEY);

                if (string.IsNullOrWhiteSpace(savedToken) || string.IsNullOrWhiteSpace(savedUserJson))
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                var savedUser = JsonSerializer.Deserialize<SavedUserInfo>(savedUserJson);
                if (savedUser == null)
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                // 设置用户会话
                _userSession.SetSession(savedUser.UserName, savedToken, savedUser.Role, savedUser.OrgId);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, savedUser.UserName),
                    new Claim(ClaimTypes.Role, savedUser.Role),
                    new Claim("OrgId", savedUser.OrgId.ToString())
                };

                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public async Task<bool> LoginAsync(string userName, string password, int orgId)
        {
            try
            {
                var loginRequest = new SignInRequset(orgId, userName, password);

                var response = await _apiClient.PostAsync<SignInRequset, SignInResponse>("/login", loginRequest);

                if (response?.IsSuccess == true && response.Data != null)
                {
                    var loginResponse = response.Data;

                    // 保存到本地存储
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TOKEN_KEY, loginResponse.Token);
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", USER_KEY,
                        JsonSerializer.Serialize(new SavedUserInfo
                        {
                            UserName = loginResponse.UserName,
                            Role = loginResponse.Role,
                            OrgId = loginResponse.OrgId
                        }));

                    // 更新用户会话
                    _userSession.SetSession(loginResponse.UserName, loginResponse.Token, loginResponse.Role, loginResponse.OrgId);

                    // 创建认证状态
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, loginResponse.UserName),
                        new Claim(ClaimTypes.Role, loginResponse.Role),
                        new Claim("OrgId", loginResponse.OrgId.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, "jwt");
                    var user = new ClaimsPrincipal(identity);

                    // 通知认证状态已改变
                    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            // 清除本地存储
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TOKEN_KEY);
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", USER_KEY);

            // 清除会话
            _userSession.ClearSession();

            // 创建空的认证状态
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }

        public async Task<ProfileResponse?> GetUserProfileAsync()
        {
            try
            {
                var response = await _apiClient.GetAsync<ProfileResponse>("/profile");
                return response?.Data;
            }
            catch
            {
                return null;
            }
        }

        // 刷新Token的方法
        public async Task<bool> RefreshTokenAsync()
        {
            try
            {
                await _apiClient.PostAsync("/refresh-token", new RefreshTokenRequest { RefreshToken = });
                return true;
            }
            catch
            {
                await LogoutAsync();
                return false;
            }
        }

        private class SavedUserInfo
        {
            public string UserName { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
            public int OrgId { get; set; }
        }
    }
}
