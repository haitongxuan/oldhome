using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Department : BaseOrgByEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StaffCount { get; set; }
        public List<Staff> StaffMembers { get; set; } = new List<Staff>();
        public List<Resident> Residents { get; set; } = new List<Resident>();
    }
}
