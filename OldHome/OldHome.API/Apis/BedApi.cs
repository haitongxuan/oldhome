using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class BedApi : BaseMessage
    {
        public BedApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<PagedResult<BedDto>>> GetPagedBeds(int pageIndex, int pageSize, int? orgAreaId, int? floor, int? roomId = null)
        {
            var urlBuilder = new StringBuilder("beds/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
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
            var response = await _apiClient.GetAsync<PagedResult<BedDto>>(urlBuilder.ToString());
            return response;
        }


        public async Task<BaseResponse<List<BedDto>>> GetAllBeds(int? orgAreaId, int? floor, int? roomId = null)
        {
            var urlBuilder = new StringBuilder("beds?index=1");
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
            var response = await _apiClient.GetAsync<List<BedDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<BedDto>> CreateBed(BedCreate create)
        {
            var response = await _apiClient.PostAsync<BedCreate, BedDto>("beds/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyBed(BedModify modify)
        {
            var response = await _apiClient.PostAsync("beds/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<BedSample>>> GetAllBedSamples(int? roomId = null)
        {
            var urlBuilder = new StringBuilder("beds/samples?index=1");
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            var response = await _apiClient.GetAsync<List<BedSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<List<BedSample>>> GetTop10BedSamples(string name)
        {
            var urlBuilder = new StringBuilder("beds/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            var response = await _apiClient.GetAsync<List<BedSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteBed(int id)
        {
            var response = await _apiClient.GetAsync("beds/delete?id=" + id);
            return response;
        }
    }
}
