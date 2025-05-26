using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Org : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public bool IsHead { get; set; } = false;
        public List<User> Users { get; set; } = new List<User>();
        public List<OrgArea> OrgAreas { get; set; } = new List<OrgArea>();
    }
}
