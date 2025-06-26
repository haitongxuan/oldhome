using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class ResidentApi : BaseMessage
    {
        public ResidentApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<PagedResult<ResidentDto>>> GetPagedResidents(int pageIndex, int pageSize, string name = "",
            int? orgAreaId = null, int? floor = null, int? roomId = null, int? bedId = null)
        {
            var urlBuilder = new StringBuilder("residents/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            if (bedId is not null)
                urlBuilder.Append("&BedId_eq=" + bedId);
            var response = await _apiClient.GetAsync<PagedResult<ResidentDto>>(urlBuilder.ToString());
            return response;
        }
        public async Task<BaseResponse<List<ResidentDto>>> GetAllResidents(string name = "", string code = "", int? orgAreaId = null, int? floor = null,
            int? roomId = null, int? bedId = null)
        {
            var urlBuilder = new StringBuilder("residents?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(code))
            {
                urlBuilder.Append("&Code_like=" + code);
            }
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            if (bedId is not null)
                urlBuilder.Append("&BedId_eq=" + bedId);
            var response = await _apiClient.GetAsync<List<ResidentDto>>(urlBuilder.ToString());
            return response;
        }
        public async Task<BaseResponse<ResidentDto>> CreateResident(ResidentCreate create)
        {
            var response = await _apiClient.PostAsync<ResidentCreate, ResidentDto>("residents/create", create);
            return response;
        }
        public async Task<BaseResponse> ModifyResident(ResidentModify modify)
        {
            var response = await _apiClient.PostAsync("residents/modify", modify);
            return response;
        }
        public async Task<BaseResponse<List<ResidentSample>>> GetAllResidentSamples(string name = "", string code = "", int? orgAreaId = null, int? floor = null,
            int? roomId = null, int? bedId = null)
        {
            var urlBuilder = new StringBuilder("residents/samples?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(code))
            {
                urlBuilder.Append("&Code_like=" + code);
            }
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            if (bedId is not null)
                urlBuilder.Append("&BedId_eq=" + bedId);
            var response = await _apiClient.GetAsync<List<ResidentSample>>(urlBuilder.ToString());
            return response;
        }
        public async Task<BaseResponse> DeleteResident(int id)
        {
            var response = await _apiClient.GetAsync("residents/delete?id=" + id);
            return response;
        }
    }
}
