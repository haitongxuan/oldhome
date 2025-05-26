using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Caregiver : BaseOrgByEntity
    {
        public string Name { get; set; } = string.Empty;
        public int StaffId { get; set; }
        public Staff Staff { get; set; } = new Staff();
        public CareLevel CareLevelCapability { get; set; }
        public bool IsFullTime { get; set; }
        public int MaxResidentCount { get; set; }
        public bool IsActive { get; set; } = true;
        public string Notes { get; set; } = string.Empty;
    }
}
