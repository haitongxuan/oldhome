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
    [Display(Name = "用药模板")]
    public class MedicationTemplate : BaseEntity
    {
        public string TemplateName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public List<MedicationTemplateItem> Items { get; set; } = new List<MedicationTemplateItem>();
    }    
}
