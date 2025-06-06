using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    /// <summary>
    /// 发药计划 - 基于处方生成的具体发药安排
    /// </summary>
    public class MedicationSchedule : BaseOrgByEntity
    {
        /// <summary>
        /// 计划编号
        /// </summary>
        public string ScheduleNumber { get; set; } = string.Empty;

        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();

        /// <summary>
        /// 处方明细ID
        /// </summary>
        public int PrescriptionItemId { get; set; }
        public MedicationPrescriptionItem PrescriptionItem { get; set; } = new MedicationPrescriptionItem();

        /// <summary>
        /// 药品ID（冗余字段）
        /// </summary>
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();

        /// <summary>
        /// 计划日期
        /// </summary>
        public DateOnly ScheduleDate { get; set; }

        /// <summary>
        /// 计划时间
        /// </summary>
        public TimeOnly ScheduleTime { get; set; }

        /// <summary>
        /// 用药时间点
        /// </summary>
        public MedicineTime MedicineTime { get; set; }

        /// <summary>
        /// 计划用药量
        /// </summary>
        public decimal PlannedDosage { get; set; }

        /// <summary>
        /// 实际用药量
        /// </summary>
        public decimal? ActualDosage { get; set; }

        /// <summary>
        /// 计划状态
        /// </summary>
        public ScheduleStatus Status { get; set; } = ScheduleStatus.Scheduled;

        /// <summary>
        /// 计划类型
        /// </summary>
        public ScheduleType ScheduleType { get; set; } = ScheduleType.Regular;

        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime? ExecutedTime { get; set; }

        /// <summary>
        /// 执行护士ID
        /// </summary>
        public int? ExecutedById { get; set; }
        public Staff? ExecutedBy { get; set; }

        /// <summary>
        /// 关联出库记录ID
        /// </summary>
        public int? OutboundItemId { get; set; }
        public InventoryOutboundItem? OutboundItem { get; set; }

        /// <summary>
        /// 跳过原因
        /// </summary>
        public string? SkipReason { get; set; }

        /// <summary>
        /// 延迟原因
        /// </summary>
        public string? DelayReason { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
