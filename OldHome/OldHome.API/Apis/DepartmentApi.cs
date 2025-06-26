using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class DepartmentApi : BaseMessage
    {
        public DepartmentApi(IApiClient apiClient) : base(apiClient)
        {
        }
        public async Task<BaseResponse<List<DepartmentDto>>> GetAllDepartments()
        {
            var response = await _apiClient.GetAsync<List<DepartmentDto>>("departments");
            return response;
        }

        public async Task<BaseResponse<DepartmentDto>> CreateDepartment(DepartmentCreate create)
        {
            var response = await _apiClient.PostAsync<DepartmentCreate, DepartmentDto>("departments/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyDepartment(DepartmentModify modify)
        {
            var response = await _apiClient.PostAsync("departments/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<DepartmentSample>>> GetAllDepartmentSamples()
        {
            var response = await _apiClient.GetAsync<List<DepartmentSample>>("departments/samples");
            return response;
        }

        public async Task<BaseResponse<List<DepartmentSample>>> GetTop10DepartmentSamples(string name)
        {
            var urlBuilder = new StringBuilder("departments/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            var response = await _apiClient.GetAsync<List<DepartmentSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteDepartment(int id)
        {
            var response = await _apiClient.GetAsync("departments/delete?id=" + id);
            return response;
        }

    }
}
