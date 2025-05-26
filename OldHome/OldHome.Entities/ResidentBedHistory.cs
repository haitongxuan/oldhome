using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class ResidentBedHistory
    {
        public int Id { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }
        public DateOnly CheckInDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly? CheckOutDate { get; set; } = null;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public int OperatorId { get; set; }
        public User Operator { get; set; }
        public string OperatorName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
