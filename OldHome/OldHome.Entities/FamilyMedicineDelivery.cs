using OldHome.Core;
using OldHome.Core.Attributes;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    /// <summary>
    /// 家属送药记录表
    /// </summary>
    public class FamilyMedicineDelivery : BaseOrgByEntity, ISerialNumberEntity
    {
        /// <summary>
        /// 送药记录号
        /// </summary>
        [SerialNumber("FAMILY_MED_DELIVERY", Prefix = "FMD")]
        public string DeliveryNumber { get; set; } = string.Empty;

        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();

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
        public User ReceivedBy { get; set; } = new User();

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
        public InventoryInbound? Inbound { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 送药明细
        /// </summary>
        public List<FamilyMedicineDeliveryItem> Items { get; set; } = new List<FamilyMedicineDeliveryItem>();
    }


}
