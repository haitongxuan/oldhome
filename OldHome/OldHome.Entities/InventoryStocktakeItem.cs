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
    /// 盘点明细
    /// </summary>
    public class InventoryStocktakeItem : BaseEntity
    {
        /// <summary>
        /// 盘点单ID
        /// </summary>
        public int StocktakeId { get; set; }
        public InventoryStocktake Stocktake { get; set; } = new InventoryStocktake();

        /// <summary>
        /// 库存记录ID
        /// </summary>
        public int InventoryId { get; set; }
        public MedicineInventory Inventory { get; set; } = new MedicineInventory();

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
        /// 账面数量
        /// </summary>
        public int BookQuantity { get; set; }

        /// <summary>
        /// 实盘数量
        /// </summary>
        public int ActualQuantity { get; set; }

        /// <summary>
        /// 差异数量
        /// </summary>
        public int DifferenceQuantity { get; set; }

        /// <summary>
        /// 单位成本
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitCost { get; set; }

        /// <summary>
        /// 差异金额
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal DifferenceAmount { get; set; }

        /// <summary>
        /// 差异原因
        /// </summary>
        public string? DifferenceReason { get; set; }

        /// <summary>
        /// 处理方式
        /// </summary>
        public string? TreatmentMethod { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
