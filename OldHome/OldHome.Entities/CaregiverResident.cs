using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class CaregiverResident
    {
        public int Id { get; set; }
        public int CaregiverId { get; set; }
        public Caregiver Caregiver { get; set; } = new Caregiver();
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly? EndDate { get; set; } = null;
        public bool IsPrimary { get; set; } = false;
        public string Notes { get; set; } = string.Empty;
    }
}
