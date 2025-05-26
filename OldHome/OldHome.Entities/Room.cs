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
    public class Room : BaseOrgByEntity
    {
        [Display(Name = "房间号（比如 A101）")]
        public string RoomNumber { get; set; } = string.Empty;
        [Display(Name = "房间类型（比如 单人间、双人间、三人间）")]
        public RoomType RoomType { get; set; }
        [Display(Name = "楼层（比如 1、2、3）")]
        public int Floor { get; set; }
        public int OrgAreaId { get; set; }
        [Display(Name = "区域")]
        public OrgArea OrgArea { get; set; }
        [Display(Name = "床位数")]
        public int BedCount { get; set; }
        public int FreeBedCount { get; set; }
        public bool IsFull { get; set; } = false;
        [Display(Name = "备注")]
        public string? Notes { get; set; } = string.Empty;
    }
}
