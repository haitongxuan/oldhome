using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class OrgAreaDto : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OrgName { get; set; } = string.Empty;
        public int FloorMax { get; set; } = 0;
        public int FloorMin { get; set; } = 0;
    }

    public class OrgAreaCreate : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int FloorMax { get; set; } = 0;
        public int FloorMin { get; set; } = 0;
    }

    public class OrgAreaModify : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int FloorMax { get; set; } = 0;
        public int FloorMin { get; set; } = 0;
    }

    public class OrgAreaSample : BaseOrgByDto
    {
        public string OrgAreaName { get; set; } = string.Empty;
        public int FloorMax { get; set; }
        public int FloorMin { get; set; }
    }
}
