using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Bed : BaseOrgByEntity
    {
        public string BedNum { get; set; } = string.Empty;
        public int OrgAreaId { get; set; }
        public OrgArea OrgArea { get; set; }
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public BedStatus Status { get; set; } = BedStatus.Free;
        public string StatusNotes { get; set; } = string.Empty;
        public bool Available { get; set; } = true;
    }
}
