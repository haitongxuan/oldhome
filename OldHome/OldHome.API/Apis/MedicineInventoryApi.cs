using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class MedicineInventoryApi : BaseMessage
    {
        public MedicineInventoryApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<PagedResult<MedicineInventoryDto>>> GetPagedMedicineInventories(int pageIndex, int pageSize,
            string batchNum = "", string residentFilter = "", string medicineFilter = "")
        {
            var urlBuilder = new StringBuilder("medicine-inventories/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (!string.IsNullOrEmpty(batchNum))
            {
                urlBuilder.Append("&BatchNumber_like=" + batchNum);
            }
            if (!string.IsNullOrEmpty(residentFilter))
            {
                urlBuilder.Append("&or_ResidentCode_ResidentName_like=" + residentFilter);
            }
            if (!string.IsNullOrEmpty(medicineFilter))
            {
                urlBuilder.Append("&or_MedicineBarcode_MedicineName_like=" + medicineFilter);
            }
            var response = await _apiClient.GetAsync<PagedResult<MedicineInventoryDto>>(urlBuilder.ToString());
            return response;
        }


        public async Task<BaseResponse<List<MedicineInventoryDto>>> GetAllMedicineInventories(string batchNum = "",
            string residentName = "", string residentCode = "", string medicineName = "", string medicineBarcode = "")
        {
            var urlBuilder = new StringBuilder("medicine-inventories?index=1");
            if (!string.IsNullOrEmpty(batchNum))
            {
                urlBuilder.Append("&BatchNumber_like=" + batchNum);
            }
            if (!string.IsNullOrEmpty(residentName))
            {
                urlBuilder.Append("&ResidentName_like=" + residentName);
            }
            if (!string.IsNullOrEmpty(residentCode))
            {
                urlBuilder.Append("&ResidentCode_like=" + residentCode);
            }
            if (!string.IsNullOrEmpty(medicineName))
            {
                urlBuilder.Append("&MedicineName_like=" + medicineName);
            }
            if (!string.IsNullOrEmpty(medicineBarcode))
            {
                urlBuilder.Append("&MedicineBarcode_like=" + medicineBarcode);
            }
            var response = await _apiClient.GetAsync<List<MedicineInventoryDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<MedicineInventoryDto>> CreateMedicineInventory(MedicineInventoryCreate create)
        {
            var response = await _apiClient.PostAsync<MedicineInventoryCreate, MedicineInventoryDto>("medicine-inventories/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyMedicineInventory(MedicineInventoryModify modify)
        {
            var response = await _apiClient.PostAsync("medicine-inventories/modify", modify);
            return response;
        }

        public async Task<BaseResponse> DeleteMedicineInventory(int id)
        {
            var response = await _apiClient.GetAsync("medicine-inventories/delete?id=" + id);
            return response;
        }
    }
}
