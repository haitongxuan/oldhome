using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class RoomApi : BaseMessage
    {
        public RoomApi(IApiClient apiClient) : base(apiClient)
        {
        }
        public async Task<BaseResponse<PagedResult<RoomDto>>> GetPagedRooms(int pageIndex, int pageSize, int? orgAreaId = null, int? floor = null)
        {
            var urlBuilder = new StringBuilder("rooms/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (orgAreaId is not null)
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            if (floor is not null)
                urlBuilder.Append("&Floor_eq=" + floor);
            var response = await _apiClient.GetAsync<PagedResult<RoomDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<RoomDto>> CreateRoom(RoomCreate create)
        {
            var response = await _apiClient.PostAsync<RoomCreate, RoomDto>("rooms/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyRoom(RoomModify modify)
        {
            var response = await _apiClient.PostAsync("rooms/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<RoomSample>>> GetAllRoomSamples(int? orgAreaId = null, int? floor = null)
        {
            var urlBuilder = new StringBuilder("rooms/samples?index=1");
            if (orgAreaId is not null)
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            if (floor is not null)
                urlBuilder.Append("&Floor_eq=" + floor);
            var response = await _apiClient.GetAsync<List<RoomSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteRoom(int id)
        {
            var response = await _apiClient.GetAsync("rooms/delete?id=" + id);
            return response;
        }
    }
}
