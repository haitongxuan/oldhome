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
    /// 发药出库明细
    /// </summary>
    public class MedicationOutboundItem : BaseEntity
    {
        /// <summary>
        /// 发药出库单ID
        /// </summary>
        public int OutboundId { get; set; }
        public MedicationOutbound Outbound { get; set; } = new MedicationOutbound();

        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();

        /// <summary>
        /// 发药计划ID
        /// </summary>
        public int ScheduleId { get; set; }
        public MedicationSchedule Schedule { get; set; } = new MedicationSchedule();

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
        /// 批次号
        /// </summary>
        public string BatchNumber { get; set; } = string.Empty;

        /// <summary>
        /// 计划用量
        /// </summary>
        public decimal PlannedQuantity { get; set; }

        /// <summary>
        /// 实际出库量
        /// </summary>
        public decimal ActualQuantity { get; set; }

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
        /// 发药状态
        /// </summary>
        public DispenseStatus DispenseStatus { get; set; } = DispenseStatus.Prepared;

        /// <summary>
        /// 用药说明
        /// </summary>
        public string Instructions { get; set; } = string.Empty;

        /// <summary>
        /// 特殊说明
        /// </summary>
        public string SpecialInstructions { get; set; } = string.Empty;

        /// <summary>
        /// 住户确认时间
        /// </summary>
        public DateTime? ResidentConfirmedTime { get; set; }

        /// <summary>
        /// 住户拒绝原因
        /// </summary>
        public string? RefusalReason { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
