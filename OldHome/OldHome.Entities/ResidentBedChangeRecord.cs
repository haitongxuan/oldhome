using OldHome.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class ResidentBedChangeRecord
    {
        public int Id { get; set; }
        public int? ResidentId { get; set; }
        public Resident? Resident { get; set; } = new Resident();
        public int? FromRoomId { get; set; }
        public Room? FromRoom { get; set; } = new Room();
        public int? FromBedId { get; set; }
        public Bed? FromBed { get; set; } = new Bed();
        public int? ToRoomId { get; set; }
        public Room? ToRoom { get; set; } = new Room();
        public int? ToBedId { get; set; }
        public Bed? ToBed { get; set; } = new Bed();
        public ResidentBadChangeType ChangeType { get; set; } = ResidentBadChangeType.CheckIn;
        public string Notes { get; set; } = string.Empty;
        public DateOnly ChangeDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public bool Cancelled { get; set; } = false;
        public int CreatorId { get; set; }
        public User Creator { get; set; } = new User();
        public string CreateBy { get; set; } = string.Empty;
    }
}
