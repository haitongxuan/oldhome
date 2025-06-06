using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    /// <summary>
    /// 用药处方 - 医生开具的用药方案
    /// </summary>
    public class MedicationPrescriptionDto : BaseOrgByDto
    {
        /// <summary>
        /// 处方号
        /// </summary>
        public string PrescriptionNumber { get; set; } = string.Empty;

        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public string ResidentName { get; set; } = string.Empty;

        /// <summary>
        /// 开方医生ID
        /// </summary>
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;

        /// <summary>
        /// 开方日期
        /// </summary>
        public DateOnly PrescriptionDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// 用药开始日期
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// 用药结束日期（可为空表示长期用药）
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// 处方类型
        /// </summary>
        public PrescriptionType PrescriptionType { get; set; } = PrescriptionType.Regular;

        /// <summary>
        /// 处方状态
        /// </summary>
        public PrescriptionStatus Status { get; set; } = PrescriptionStatus.Active;

        /// <summary>
        /// 诊断说明
        /// </summary>
        public string Diagnosis { get; set; } = string.Empty;

        /// <summary>
        /// 处方备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 审核医生ID
        /// </summary>
        public int? ReviewedById { get; set; }
        public string? ReviewedByName { get; set; } = string.Empty;

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateOnly? ReviewedDate { get; set; }

        /// <summary>
        /// 处方明细
        /// </summary>
        public List<MedicationPrescriptionItemDto> Items { get; set; } = new List<MedicationPrescriptionItemDto>();
    }

    /// <summary>
    /// 处方明细 - 具体的用药安排
    /// </summary>
    public class MedicationPrescriptionItemDto : BaseOrgByDto
    {
        /// <summary>
        /// 处方ID
        /// </summary>
        public int PrescriptionId { get; set; }

        /// <summary>
        /// 药品ID
        /// </summary>
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;

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
