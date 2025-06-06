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
    public class InventoryInboundDto : BaseOrgByDto
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        public string InboundNumber { get; set; } = string.Empty;

        /// <summary>
        /// 入库类型
        /// </summary>
        public InboundType InboundType { get; set; }

        /// <summary>
        /// 药品来源类型
        /// </summary>
        public MedicineSourceType SourceType { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateOnly InboundDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// 来源详情
        /// </summary>
        public string SourceDetails { get; set; } = string.Empty;

        /// <summary>
        /// 提供人信息
        /// </summary>
        public string? ProviderInfo { get; set; }

        /// <summary>
        /// 提供人与住户关系
        /// </summary>
        public ContactRelationship? ProviderRelationship { get; set; }

        /// <summary>
        /// 关联住户ID（家属提供时）
        /// </summary>
        public int? ResidentId { get; set; }
        public string? ResidentName { get; set; }

        /// <summary>
        /// 购买凭证
        /// </summary>
        public string? PurchaseReference { get; set; }

        /// <summary>
        /// 总价值（可选）
        /// </summary>
        public decimal? TotalValue { get; set; }

        /// <summary>
        /// 入库状态
        /// </summary>
        public InboundStatus Status { get; set; } = InboundStatus.Draft;

        /// <summary>
        /// 验收人员ID
        /// </summary>
        public int? CheckedById { get; set; }
        public string? CheckedByName { get; set; }

        /// <summary>
        /// 验收日期
        /// </summary>
        public DateOnly? CheckedDate { get; set; }

        /// <summary>
        /// 入库人员ID
        /// </summary>
        public int? InboundById { get; set; }
        public string? InboundByName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 入库明细
        /// </summary>
        public List<InventoryInboundItemDto> Items { get; set; } = new List<InventoryInboundItemDto>();
    }

    public class InventoryInboundItemDto : BaseOrgByDto
    {
        /// <summary>
        /// 药品ID
        /// </summary>
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;

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
        /// 最小单位数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 单价（可选）
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// 总价（可选）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// 存储位置
        /// </summary>
        public string StorageLocation { get; set; } = string.Empty;

        /// <summary>
        /// 库存类型
        /// </summary>
        public MedicineInventoryType InventoryType { get; set; } = MedicineInventoryType.Public;

        /// <summary>
        /// 验收数量
        /// </summary>
        public int? CheckedQuantity { get; set; }

        /// <summary>
        /// 验收状态
        /// </summary>
        public CheckStatus CheckStatus { get; set; } = CheckStatus.Pending;

        /// <summary>
        /// 验收备注
        /// </summary>
        public string? CheckNotes { get; set; }

        /// <summary>
        /// 关联的库存记录ID
        /// </summary>
        public int? InventoryId { get; set; }
        public string? InventoryBatchNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
