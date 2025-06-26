using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class MedicineApi : BaseMessage
    {
        public MedicineApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<PagedResult<MedicineDto>>> GetPagedMedicines(int pageIndex, int pageSize, string name = "", string barcode = "")
        {
            var urlBuilder = new StringBuilder("medicines/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(barcode))
            {
                urlBuilder.Append("&Barcode_like=" + barcode);
            }
            var response = await _apiClient.GetAsync<PagedResult<MedicineDto>>(urlBuilder.ToString());
            return response;
        }


        public async Task<BaseResponse<List<MedicineDto>>> GetAllMedicines()
        {
            var response = await _apiClient.GetAsync<List<MedicineDto>>("medicines");
            return response;
        }

        public async Task<BaseResponse<MedicineDto>> CreateMedicine(MedicineCreate create)
        {
            var response = await _apiClient.PostAsync<MedicineCreate, MedicineDto>("medicines/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyMedicine(MedicineModify modify)
        {
            var response = await _apiClient.PostAsync("medicines/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<MedicineSample>>> GetAllMedicineSamples(string name = "", string barcode = "")
        {
            var urlBuilder = new StringBuilder("medicines/samples?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(barcode))
            {
                urlBuilder.Append("&Barcode_like=" + barcode);
            }
            var response = await _apiClient.GetAsync<List<MedicineSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<List<MedicineSample>>> GetTop10MedicineSamples(string name = "", string barcode = "")
        {
            var urlBuilder = new StringBuilder("medicines/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(barcode))
            {
                urlBuilder.Append("&Barcode_like=" + barcode);
            }
            var response = await _apiClient.GetAsync<List<MedicineSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteMedicine(int id)
        {
            var response = await _apiClient.GetAsync("medicines/delete?id=" + id);
            return response;
        }
    }
}
