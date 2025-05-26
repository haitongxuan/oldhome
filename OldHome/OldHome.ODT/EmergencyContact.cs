using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class EmergencyContactDto : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }

    public class EmergencyContactCreate : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class EmergencyContactModify : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class EmergencyContactSample : BaseOrgByDto
    {
        public string ContactName { get; set; } = string.Empty;
    }
}
