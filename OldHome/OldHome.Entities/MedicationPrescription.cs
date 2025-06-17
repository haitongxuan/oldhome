using OldHome.Core;
using OldHome.Core.Attributes;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    /// <summary>
    /// 用药处方 - 医生开具的用药方案
    /// </summary>
    public class MedicationPrescription : BaseOrgByEntity, ISerialNumberEntity
    {
        /// <summary>
        /// 处方号
        /// </summary>
        [SerialNumber("PRESCRIPTION", Prefix = "RX")]
        public string PrescriptionNumber { get; set; } = string.Empty;

        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }

        ///// <summary>
        ///// 开方医生ID
        ///// </summary>
        //public int DoctorId { get; set; }
        //public Staff Doctor { get; set; }

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
        //public int? ReviewedById { get; set; }
        //public Staff? ReviewedBy { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateOnly? ReviewedDate { get; set; }

        /// <summary>
        /// 处方明细
        /// </summary>
        public List<MedicationPrescriptionItem> Items { get; set; } = new List<MedicationPrescriptionItem>();
    }
}
