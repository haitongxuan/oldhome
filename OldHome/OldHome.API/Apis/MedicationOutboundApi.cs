using OldHome.API.Services;
using OldHome.Core;
using OldHome.DTO.Base;
using OldHome.DTO;
using System.Text;

namespace OldHome.API.Apis
{
    public class MedicationOutboundApi : BaseMessage
    {
        public MedicationOutboundApi(IApiClient apiClient) : base(apiClient)
        {
        }

        /// <summary>
        /// 获取分页发药出库单列表
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="medicineTime">发药时间段</param>
        /// <param name="outboundType">发药类型</param>
        /// <param name="status">出库状态</param>
        /// <param name="pharmacistId">发药护士ID</param>
        /// <returns></returns>
        public async Task<BaseResponse<PagedResult<MedicationOutboundDto>>> GetPagedMedicationOutbounds(
            int pageIndex,
            int pageSize,
            DateTime? startDate = null,
            DateTime? endDate = null,
            MedicineTime? medicineTime = null,
            MedicationOutboundType? outboundType = null,
            MedicationOutboundStatus? status = null,
            int? pharmacistId = null)
        {
            var urlBuilder = new StringBuilder($"medication-outbounds/paged?pageIndex={pageIndex}&pageSize={pageSize}");

            if (startDate.HasValue)
            {
                urlBuilder.Append($"&OutboundDate_gte={startDate.Value:yyyy-MM-dd}");
            }
            if (endDate.HasValue)
            {
                urlBuilder.Append($"&OutboundDate_lte={endDate.Value:yyyy-MM-dd}");
            }
            if (medicineTime.HasValue)
            {
                urlBuilder.Append($"&MedicineTime_eq={(int)medicineTime.Value}");
            }
            if (outboundType.HasValue)
            {
                urlBuilder.Append($"&OutboundType_eq={(int)outboundType.Value}");
            }
            if (status.HasValue)
            {
                urlBuilder.Append($"&Status_eq={(int)status.Value}");
            }
            if (pharmacistId.HasValue)
            {
                urlBuilder.Append($"&PharmacistId_eq={pharmacistId.Value}");
            }

            var response = await _apiClient.GetAsync<PagedResult<MedicationOutboundDto>>(urlBuilder.ToString());
            return response;
        }


        public async Task<BaseResponse<List<MedicationOutboundDto>>> GetAllMedicationOutbounds()
        {
            var response = await _apiClient.GetAsync<List<MedicationOutboundDto>>("medication-outbounds");
            return response;
        }

        public async Task<BaseResponse<MedicationOutboundDto>> CreateMedicationOutbound(MedicationOutboundCreateDto create)
        {
            var response = await _apiClient.PostAsync<MedicationOutboundCreateDto, MedicationOutboundDto>("medication-outbounds/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyMedicationOutbound(MedicationOutboundModifyDto modify)
        {
            var response = await _apiClient.PostAsync("medication-outbounds/modify", modify);
            return response;
        }

        public async Task<BaseResponse> DeleteMedicationOutbound(int id)
        {
            var response = await _apiClient.GetAsync("medication-outbounds/delete?id=" + id);
            return response;
        }
    }
}
