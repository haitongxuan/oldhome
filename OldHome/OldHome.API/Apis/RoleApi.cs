using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;

namespace OldHome.API.Apis
{
    public class RoleApi : BaseMessage
    {
        public RoleApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<List<RoleDto>>> GetAllRoles()
        {
            var response = await _apiClient.GetAsync<List<RoleDto>>("roles");
            return response;
        }

        public async Task<BaseResponse<List<RoleSample>>> GetAllRoleSamples()
        {
            var response = await _apiClient.GetAsync<List<RoleSample>>("roles/samples");
            return response;
        }

        public async Task<BaseResponse<RoleDto>> CreateRole(RoleCreate roleCreate)
        {
            var response = await _apiClient.PostAsync<RoleCreate, RoleDto>("roles/create", roleCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyRole(RoleModify roleModify)
        {
            var response = await _apiClient.PostAsync("roles/modify", roleModify);
            return response;
        }

        public async Task<BaseResponse> DeleteRole(int id)
        {
            var response = await _apiClient.GetAsync($"roles/delete?id={id}");
            return response;
        }
    }
}
