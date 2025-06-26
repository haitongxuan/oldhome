using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;

namespace OldHome.API.Apis
{
    public class UserApi : BaseMessage
    {
        public UserApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<List<UserDto>>> GetAllUsers()
        {
            var response = await _apiClient.GetAsync<List<UserDto>>("users");
            return response;
        }

        public async Task<BaseResponse<PagedResult<UserDto>>> GetPagedUsers(int pageIndex, int pageSize)
        {
            var response = await _apiClient.GetAsync<PagedResult<UserDto>>($"users/paged?pageIndex={pageIndex}&pageSize={pageSize}");
            return response;
        }

        public async Task<BaseResponse<UserDto>> CreateUser(UserCreate userCreate)
        {
            var response = await _apiClient.PostAsync<UserCreate, UserDto>("users/create", userCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyUser(UserModify userModify)
        {
            var response = await _apiClient.PostAsync("users/modify", userModify);
            return response;
        }

        public async Task<BaseResponse> DeleteUser(int id)
        {
            var response = await _apiClient.GetAsync($"users/delete?id={id}");
            return response;
        }
    }
}
