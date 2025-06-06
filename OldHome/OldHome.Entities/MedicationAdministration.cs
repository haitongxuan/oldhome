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
    /// 用药执行记录 - 详细记录每次用药的执行情况
    /// </summary>
    public class MedicationAdministration : BaseOrgByEntity
    {
        /// <summary>
        /// 执行记录号
        /// </summary>
        public string AdministrationNumber { get; set; } = string.Empty;

        /// <summary>
        /// 发药计划ID
        /// </summary>
        public int ScheduleId { get; set; }
        public MedicationSchedule Schedule { get; set; } = new MedicationSchedule();

        /// <summary>
        /// 发药出库明细ID
        /// </summary>
        public int? OutboundItemId { get; set; }
        public MedicationOutboundItem? OutboundItem { get; set; }

        /// <summary>
        /// 住户ID（冗余字段）
        /// </summary>
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();

        /// <summary>
        /// 药品ID（冗余字段）
        /// </summary>
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();

        /// <summary>
        /// 计划给药时间
        /// </summary>
        public DateTime ScheduledTime { get; set; }

        /// <summary>
        /// 实际给药时间
        /// </summary>
        public DateTime? ActualTime { get; set; }

        /// <summary>
        /// 计划用量
        /// </summary>
        public decimal ScheduledDosage { get; set; }

        /// <summary>
        /// 实际用量
        /// </summary>
        public decimal? ActualDosage { get; set; }

        /// <summary>
        /// 执行状态
        /// </summary>
        public AdministrationStatus Status { get; set; } = AdministrationStatus.Scheduled;

        /// <summary>
        /// 给药护士ID
        /// </summary>
        public int? AdministeredById { get; set; }
        public Staff? AdministeredBy { get; set; }

        /// <summary>
        /// 监督护士ID（双人核对）
        /// </summary>
        public int? SupervisorId { get; set; }
        public Staff? Supervisor { get; set; }

        /// <summary>
        /// 住户反应
        /// </summary>
        public string? ResidentReaction { get; set; }

        /// <summary>
        /// 不良反应
        /// </summary>
        public string? AdverseReaction { get; set; }

        /// <summary>
        /// 拒药原因
        /// </summary>
        public string? RefusalReason { get; set; }

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
