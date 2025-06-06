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
    /// 处方明细 - 具体的用药安排
    /// </summary>
    public class MedicationPrescriptionItem : BaseEntity
    {
        /// <summary>
        /// 处方ID
        /// </summary>
        public int PrescriptionId { get; set; }
        public MedicationPrescription Prescription { get; set; } = new MedicationPrescription();

        /// <summary>
        /// 药品ID
        /// </summary>
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();

        /// <summary>
        /// 单次用量
        /// </summary>
        public string Dosage { get; set; } = string.Empty; // 如：1片、2ml、半片

        /// <summary>
        /// 单次用量数值（便于计算）
        /// </summary>
        public decimal DosageAmount { get; set; }

        /// <summary>
        /// 用药频次
        /// </summary>
        public MedicationFrequency Frequency { get; set; }

        /// <summary>
        /// 每日用药次数
        /// </summary>
        public int TimesPerDay { get; set; }

        /// <summary>
        /// 具体用药时间点
        /// </summary>
        public List<MedicineTime> MedicationTimes { get; set; } = new List<MedicineTime>();

        /// <summary>
        /// 用药方式
        /// </summary>
        public MedicineType MedicationType { get; set; }

        /// <summary>
        /// 用药指导
        /// </summary>
        public string Instructions { get; set; } = string.Empty;

        /// <summary>
        /// 特殊说明
        /// </summary>
        public string SpecialInstructions { get; set; } = string.Empty;

        /// <summary>
        /// 是否PRN用药（按需用药）
        /// </summary>
        public bool IsPRN { get; set; } = false;

        /// <summary>
        /// PRN用药条件
        /// </summary>
        public string? PRNCondition { get; set; }

        /// <summary>
        /// 最大日用量（PRN用药时）
        /// </summary>
        public decimal? MaxDailyDose { get; set; }

        /// <summary>
        /// 明细状态
        /// </summary>
        public PrescriptionItemStatus Status { get; set; } = PrescriptionItemStatus.Active;

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
