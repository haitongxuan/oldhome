using OldHome.API.Services;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class MedicationPrescriptionApi : BaseMessage
    {
        public MedicationPrescriptionApi(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<BaseResponse<PagedResult<MedicationPrescriptionDto>>> GetPagedMedicationPrescriptions
            (int pageIndex, int pageSize, int? residentId = null)
        {
            var urlBuilder = new StringBuilder("medication-prescriptions/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (residentId != null)
            {
                urlBuilder.Append("&ResidentId_eq=" + residentId);
            }
            var response = await _apiClient.GetAsync<PagedResult<MedicationPrescriptionDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<MedicationPrescriptionDto>> CreateMedicationPrescription(MedicationPrescriptionDto create)
        {
            var response = await _apiClient.PostAsync<MedicationPrescriptionDto, MedicationPrescriptionDto>("medication-prescriptions/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyMedicationPrescription(MedicationPrescriptionDto modify)
        {
            var response = await _apiClient.PostAsync("medication-prescriptions/modify-items", modify);
            return response;
        }

        public async Task<BaseResponse> DeleteMedicationPrescription(int id)
        {
            var response = await _apiClient.GetAsync("medication-prescriptions/delete?id=" + id);
            return response;
        }
    }
}
