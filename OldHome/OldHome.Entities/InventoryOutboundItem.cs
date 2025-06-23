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
    /// 出库单明细
    /// </summary>
    public class InventoryOutboundItem : BaseEntity
    {
        /// <summary>
        /// 出库单ID
        /// </summary>
        public int OutboundId { get; set; }
        public InventoryOutbound Outbound { get; set; } = new InventoryOutbound();

        /// <summary>
        /// 库存记录ID
        /// </summary>
        public int InventoryId { get; set; }
        public MedicineInventory Inventory { get; set; } = new MedicineInventory();

        /// <summary>
        /// 药品ID（冗余字段）
        /// </summary>
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();

        /// <summary>
        /// 关联住户ID（如果是药品是家属提供）
        /// </summary>
        public int? ResidentId { get; set; }
        public Resident? Resident { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNumber { get; set; } = string.Empty;

        /// <summary>
        /// 申请数量
        /// </summary>
        public int RequestedQuantity { get; set; }

        /// <summary>
        /// 实际出库数量
        /// </summary>
        public int ActualQuantity { get; set; }

        /// <summary>
        /// 单位成本
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitCost { get; set; }

        /// <summary>
        /// 总成本
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateOnly ExpirationDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
