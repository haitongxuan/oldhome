using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class RoomDto : BaseOrgByDto
    {
        public string RoomNumber { get; set; } = string.Empty;
        public RoomType RoomType { get; set; } = RoomType.Double;
        public int OrgAreaId { get; set; }
        public string OrgAreaName { get; set; } = string.Empty;
        public int Floor { get; set; }
        public int BedCount { get; set; }
        public int FreeBedCount { get; set; }
        public bool IsFull { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class RoomCreate : BaseOrgByDto
    {
        public string RoomNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public RoomType RoomType { get; set; } = RoomType.Double;
        public int OrgAreaId { get; set; }
        public int BedCount { get; set; }
        public int FreeBedCount { get; set; }
        public bool IsFull { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class RoomModify : BaseOrgByDto
    {
        public string RoomNumber { get; set; } = string.Empty;
        public int OrgAreaId { get; set; }
        public int Floor { get; set; }
        public RoomType RoomType { get; set; } = RoomType.Double;
        public int BedCount { get; set; }
        public int FreeBedCount { get; set; }
        public bool IsFull { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class RoomSample : BaseOrgByDto
    {
        public string RoomName { get; set; } = string.Empty;
    }
}
