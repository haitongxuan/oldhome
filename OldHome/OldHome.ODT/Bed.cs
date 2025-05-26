using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class BedDto : BaseOrgByDto
    {
        public string BedNum { get; set; } = string.Empty;
        public int OrgAreaId { get; set; }
        public string OrgAreaName { get; set; } = string.Empty;
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public BedStatus Status { get; set; } = BedStatus.Free;
        public string StatusNotes { get; set; } = string.Empty;
        public bool Available { get; set; }
    }

    public class BedCreate : BaseOrgByDto
    {
        public string BedNum { get; set; } = string.Empty;
        public int OrgAreaId { get; set; }
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public BedStatus Status { get; set; } = BedStatus.Free;
        public string StatusNotes { get; set; } = string.Empty;
        public bool Available { get; set; }
    }

    public class BedModify : BaseOrgByDto
    {
        public string BedNum { get; set; } = string.Empty;
        public int OrgAreaId { get; set; }
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public BedStatus Status { get; set; } = BedStatus.Free;
        public string StatusNotes { get; set; } = string.Empty;
        public bool Available { get; set; }
    }

    public class BedSample : BaseOrgByDto
    {
        public string BedNum { get; set; } = string.Empty;
        public BedStatus Status { get; set; } = BedStatus.Free;
        public bool Available { get; set; }
    }
}
