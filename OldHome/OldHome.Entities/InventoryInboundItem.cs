using OldHome.Core;
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
    /// 入库单明细 - 简化版
    /// </summary>
    public class InventoryInboundItem : BaseEntity
    {
        /// <summary>
        /// 入库单ID
        /// </summary>
        public int InboundId { get; set; }
        public InventoryInbound Inbound { get; set; } = new InventoryInbound();

        /// <summary>
        /// 药品ID
        /// </summary>
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();

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
        public MedicineInventory? Inventory { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
