using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;

namespace OldHome.API.Apis
{
    public class OrgAreaApi : BaseMessage
    {
        public OrgAreaApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<List<OrgAreaDto>>> GetAllOrgAreas()
        {
            var response = await _apiClient.GetAsync<List<OrgAreaDto>>("orgareas");
            return response;
        }

        public async Task<BaseResponse<List<OrgAreaSample>>> GetAllOrgAreaSamples()
        {
            var response = await _apiClient.GetAsync<List<OrgAreaSample>>("orgareas/samples");
            return response;
        }

        public async Task<BaseResponse<OrgAreaDto>> CreateOrgArea(OrgAreaCreate orgCreate)
        {
            var response = await _apiClient.PostAsync<OrgAreaCreate, OrgAreaDto>("orgareas/create", orgCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyOrgArea(OrgAreaModify orgModify)
        {
            var response = await _apiClient.PostAsync("orgareas/modify", orgModify);
            return response;
        }

        public async Task<BaseResponse> DeleteOrgArea(int id)
        {
            var response = await _apiClient.GetAsync($"orgareas/delete?id={id}");
            return response;
        }
    }
}
