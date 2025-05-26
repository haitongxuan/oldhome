using OldHome.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    [Display(Name = "用药模板项")]
    public class MedicationTemplateItem
    {
        public int Id { get; set; }
        public int MedicationTemplateId { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();
        public MedicineTime MedicineTime { get; set; }
        public MedicineType MedicineType { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
