using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;

namespace OldHome.API.Apis
{
    public class AuthApi : BaseMessage
    {
        public AuthApi(IApiClient apiClient) : base(apiClient)
        {
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="orgId">组织ID</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>登录响应，包含访问令牌和刷新令牌</returns>
        public async Task<BaseResponse<SignInResponse>?> SignIn(int orgId, string username, string password)
        {
            var response = await _apiClient.PostAsync<SignInRequset, SignInResponse>("login", new SignInRequset(orgId, username, password));
            return response;
        }

        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="refreshToken">刷新令牌</param>
        /// <returns>新的登录响应</returns>
        public async Task<BaseResponse<SignInResponse>?> RefreshToken(string refreshToken)
        {
            var response = await _apiClient.PostAsync<RefreshTokenRequest, SignInResponse>("auth/refresh-token",
                new RefreshTokenRequest { RefreshToken = refreshToken });
            return response;
        }

        /// <summary>
        /// 获取用户资料
        /// </summary>
        /// <returns>用户资料信息</returns>
        public async Task<BaseResponse<ProfileResponse>?> GetProfile()
        {
            var response = await _apiClient.GetAsync<ProfileResponse>("profile");
            return response;
        }

        /// <summary>
        /// 获取安全数据（测试接口）
        /// </summary>
        /// <returns>受保护的数据</returns>
        public async Task<BaseResponse<string>?> SecureData()
        {
            var response = await _apiClient.GetAsync<string>("secure-data");
            return response;
        }

        /// <summary>
        /// 撤销特定刷新令牌
        /// </summary>
        /// <param name="refreshToken">要撤销的刷新令牌</param>
        /// <returns>撤销结果</returns>
        public async Task<BaseResponse?> RevokeToken(string refreshToken)
        {
            var response = await _apiClient.PostAsync("auth/revoke-token", new RevokeTokenRequest { RefreshToken = refreshToken });
            return response;
        }

        /// <summary>
        /// 用户登出（撤销所有刷新令牌）
        /// </summary>
        /// <returns>登出结果</returns>
        public async Task<BaseResponse?> Logout()
        {
            var response = await _apiClient.PostAsync("auth/logout", new { });
            return response;
        }
    }
}