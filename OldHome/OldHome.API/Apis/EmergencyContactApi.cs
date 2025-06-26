using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class EmergencyContactApi : BaseMessage
    {
        public EmergencyContactApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<PagedResult<EmergencyContactDto>>> GetPagedEmergencyContacts(int pageIndex, int pageSize,
            string name = "", string phoneNum = "", string address = "")
        {
            var urlBuilder = new StringBuilder($"emergencycontacts/paged?pageIndex={pageIndex}&pageSize={pageSize}");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                urlBuilder.Append($"&PhoneNum_like={phoneNum}");
            }
            if (!string.IsNullOrEmpty(address))
            {
                urlBuilder.Append($"&Address_like={address}");
            }
            var response = await _apiClient.GetAsync<PagedResult<EmergencyContactDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<List<EmergencyContactSample>>> GetTop10EmergencyContactSamples(string name, string phoneNum)
        {
            var urlBuilder = new StringBuilder($"emergencycontacts/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                urlBuilder.Append($"&PhoneNum_like={phoneNum}");
            }
            var response = await _apiClient.GetAsync<List<EmergencyContactSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<EmergencyContactDto>> CreateEmergencyContact(EmergencyContactCreate emergencyContactCreate)
        {
            var response = await _apiClient.PostAsync<EmergencyContactCreate, EmergencyContactDto>("emergencycontacts/create", emergencyContactCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyEmergencyContact(EmergencyContactModify emergencyContactModify)
        {
            var response = await _apiClient.PostAsync("emergencycontacts/modify", emergencyContactModify);
            return response;
        }

        public async Task<BaseResponse> DeleteEmergencyContact(int id)
        {
            var response = await _apiClient.GetAsync($"emergencycontacts/delete?id={id}");
            return response;
        }
    }
}
