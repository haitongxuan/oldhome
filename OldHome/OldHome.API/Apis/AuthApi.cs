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
        public async Task<BaseResponse<SignInResponse>?> SignIn(int orgId, string username, string password)
        {
            var response = await _apiClient.PostAsync<SignInRequset, SignInResponse>("login", new SignInRequset(orgId, username, password));
            return response;
        }

        public async Task<BaseResponse<ProfileResponse>?> GetProfile()
        {
            var response = await _apiClient.GetAsync<ProfileResponse>("profile");
            return response;
        }

        public async Task<BaseResponse<string>?> SecureData()
        {
            var response = await _apiClient.GetAsync<string>("secure-data");
            return response;
        }
    }
}
