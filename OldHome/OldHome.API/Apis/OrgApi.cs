using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;

namespace OldHome.API.Apis
{
    public class OrgApi : BaseMessage
    {
        public OrgApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<List<OrgDto>>> GetAllOrgs()
        {
            var response = await _apiClient.GetAsync<List<OrgDto>>("orgs");
            return response;
        }

        public async Task<BaseResponse<List<OrgSample>>> GetAllOrgSamples()
        {
            var response = await _apiClient.GetAsync<List<OrgSample>>("orgs/samples");
            return response;
        }

        public async Task<BaseResponse<OrgDto>> CreateOrg(OrgCreate orgCreate)
        {
            var response = await _apiClient.PostAsync<OrgCreate, OrgDto>("orgs/create", orgCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyOrg(OrgModify orgModify)
        {
            var response = await _apiClient.PostAsync("orgs/modify", orgModify);
            return response;
        }

        public async Task<BaseResponse> DeleteOrg(int id)
        {
            var response = await _apiClient.GetAsync($"orgs/delete?id={id}");
            return response;
        }

        public async Task<BaseResponse<List<OrgAreaDto>>> GetOrgAreas(int orgId)
        {
            var response = await _apiClient.GetAsync<List<OrgAreaDto>>($"orgs/{orgId}/orgareas");
            return response;
        }
    }
}
