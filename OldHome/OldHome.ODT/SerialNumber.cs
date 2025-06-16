using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class SerialNumber : BaseOrgByDto
    {
        public string Type { get; set; } = string.Empty;
        public int CurrentValue { get; set; }
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
