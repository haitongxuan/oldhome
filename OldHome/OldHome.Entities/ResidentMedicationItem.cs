using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class ResidentMedicationItem : BaseOrgByEntity
    {
        public int ResidentMedicationId { get; set; }
        public ResidentMedication ResidentMedication { get; set; } = new ResidentMedication();
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();
        public MedicineTime MedicineTime { get; set; }
        public MedicineType MedicineType { get; set; }
        [Display(Name = "生效开始日期")]
        public DateOnly EffectiveDateFrom { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        [Display(Name = "生效结束日期（可为空，长期服用）")]
        public DateOnly? EffectiveDateTo { get; set; } = null;
        public string Notes { get; set; } = string.Empty;
    }
}
