using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class StaffApi : BaseMessage
    {
        public StaffApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<PagedResult<StaffDto>>> GetPagedStaffs(int pageIndex, int pageSize, string name = "", string phoneNum = "", int? deptId = null)
        {
            var urlBuilder = new StringBuilder($"staffs/paged?pageIndex={pageIndex}&pageSize={pageSize}");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                urlBuilder.Append($"&PhoneNumber_like={phoneNum}");
            }
            if (deptId is not null)
                urlBuilder.Append($"&DepartmentId_eq={deptId}");
            var response = await _apiClient.GetAsync<PagedResult<StaffDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<StaffDto>> CreateStaff(StaffCreateDto staffCreate)
        {
            var response = await _apiClient.PostAsync<StaffCreateDto, StaffDto>("staffs/create", staffCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyStaff(StaffModifyDto staffModify)
        {
            var response = await _apiClient.PostAsync("staffs/modify", staffModify);
            return response;
        }

        public async Task<BaseResponse<List<StaffSample>>> GetAllStaffSamples(string name = null)
        {
            var urlBuilder = new StringBuilder($"staffs/samples?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            var response = await _apiClient.GetAsync<List<StaffSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<List<StaffSample>>> GetTop10StaffSamples(string name = null)
        {
            var urlBuilder = new StringBuilder($"staffs/top10samples?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            var response = await _apiClient.GetAsync<List<StaffSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteStaff(int id)
        {
            var response = await _apiClient.GetAsync($"staffs/delete?id={id}");
            return response;
        }
    }
}
