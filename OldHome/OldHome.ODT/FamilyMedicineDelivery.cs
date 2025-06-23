using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    /// <summary>
    /// 家属送药记录 DTO
    /// </summary>
    public class FamilyMedicineDeliveryDto : BaseOrgByDto
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

        /// <summary>
        /// 送药明细
        /// </summary>
        public List<FamilyMedicineDeliveryItemDto> Items { get; set; } = new List<FamilyMedicineDeliveryItemDto>();
    }

    /// <summary>
    /// 家属送药记录创建 DTO
    /// </summary>
    public class FamilyMedicineDeliveryCreateDto : BaseOrgByDto
    {
        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }

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

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime ReceivedTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 状态
        /// </summary>
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Received;

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 送药明细
        /// </summary>
        public List<FamilyMedicineDeliveryItemDto> Items { get; set; } = new List<FamilyMedicineDeliveryItemDto>();
    }

    /// <summary>
    /// 家属送药记录修改 DTO
    /// </summary>
    public class FamilyMedicineDeliveryModifyDto : BaseOrgByDto
    {
        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }

        /// <summary>
        /// 送药日期
        /// </summary>
        public DateOnly DeliveryDate { get; set; }

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

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime ReceivedTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public DeliveryStatus Status { get; set; }

        /// <summary>
        /// 关联入库单ID
        /// </summary>
        public int? InboundId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 送药明细
        /// </summary>
        public List<FamilyMedicineDeliveryItemDto> Items { get; set; } = new List<FamilyMedicineDeliveryItemDto>();
    }

    /// <summary>
    /// 家属送药记录样例 DTO
    /// </summary>
    public class FamilyMedicineDeliverySampleDto : BaseOrgByDto
    {
        /// <summary>
        /// 送药记录号
        /// </summary>
        public string DeliveryNumber { get; set; } = string.Empty;

        /// <summary>
        /// 住户姓名
        /// </summary>
        public string ResidentName { get; set; } = string.Empty;

        /// <summary>
        /// 送药日期
        /// </summary>
        public DateOnly DeliveryDate { get; set; }

        /// <summary>
        /// 送药人信息（姓名 - 电话）
        /// </summary>
        public string DeliveryPersonInfo { get; set; } = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        public DeliveryStatus Status { get; set; }
    }

    /// <summary>
    /// 家属送药明细 DTO
    /// </summary>
    public class FamilyMedicineDeliveryItemDto : BaseDto
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
        /// 规格
        /// </summary>
        public string Specification { get; set; } = string.Empty;

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNumber { get; set; } = string.Empty;

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateOnly ProductionDate { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateOnly ExpirationDate { get; set; }
        /// <summary>
        /// 包装数量
        /// </summary>
        public int PackageQuantity { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 包装单位
        /// </summary>
        public MedicinePackageUnit Unit { get; set; } = MedicinePackageUnit.Box;

        /// <summary>
        /// 购买地点
        /// </summary>
        public string? PurchaseLocation { get; set; }

        /// <summary>
        /// 购买价格（可选）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }

        /// <summary>
        /// 验收状态
        /// </summary>
        public CheckStatus CheckStatus { get; set; } = CheckStatus.Pending;

        /// <summary>
        /// 验收备注
        /// </summary>
        public string? CheckNotes { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}