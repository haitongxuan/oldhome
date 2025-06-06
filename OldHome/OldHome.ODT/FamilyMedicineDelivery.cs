using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class FamilyMedicineDelivery : BaseOrgByDto
    {
        /// <summary>
        /// 送药记录号
        /// </summary>
        public string DeliveryNumber { get; set; } = string.Empty;
        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public string ResidentName { get; set; } = string.Empty;
        /// <summary>
        /// 送药日期
        /// </summary>
        public DateOnly DeliveryDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        /// <summary>
        /// 送药人姓名
        /// </summary>
        public string DeliveryPersonName { get; set; } = string.Empty;
        /// <summary>
        /// 送药人联系方式
        /// </summary>
        public string DeliveryPersonPhone { get; set; } = string.Empty;
        /// <summary>
        /// 与住户关系
        /// </summary>
        public ContactRelationship RelationshipToResident { get; set; }
        /// <summary>
        /// 身份证号（验证身份）
        /// </summary>
        public string? IdentityCardNumber { get; set; }
        /// <summary>
        /// 接收人员ID
        /// </summary>
        public int ReceivedById { get; set; }
        public string ReceivedByName { get; set; } = string.Empty;
        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime ReceivedTime { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// 状态
        /// </summary>
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Received;

        /// <summary>
        /// 关联入库单ID
        /// </summary>
        public int? InboundId { get; set; }
        public string? InboundNumber { get; set; } = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        public List<FamilyMedicineDeliveryItemDto> Items { get; set; } = new List<FamilyMedicineDeliveryItemDto>();
    }

    public class FamilyMedicineDeliveryItemDto : BaseOrgByDto
    {
        /// <summary>
        /// 送药记录ID
        /// </summary>
        public int DeliveryId { get; set; }
        /// <summary>
        /// 药品ID
        /// </summary>
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        /// <summary>
        /// 药品规格
        /// </summary>
        public string Specification { get; set; } = string.Empty;
        /// <summary>
        /// 送药数量
        /// </summary>
        public int Quantity { get; set; } = 1;
        /// <summary>
        /// 包装单位
        /// </summary>
        public MedicinePackageUnit Unit { get; set; } = MedicinePackageUnit.Box;

        /// <summary>
        /// 验收状态
        /// </summary>
        public CheckStatus CheckStatus { get; set; } = CheckStatus.Pending;
        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
