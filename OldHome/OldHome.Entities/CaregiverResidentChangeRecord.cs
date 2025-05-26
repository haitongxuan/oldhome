using OldHome.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class CaregiverResidentChangeRecord
    {
        public int Id { get; set; }
        public int FromCaregiverId { get; set; }
        public Caregiver FromCaregiver { get; set; } = new Caregiver();
        public int ToCaregiverId { get; set; }
        public Caregiver ToCaregiver { get; set; } = new Caregiver();
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();
        public CaregiverResidentChangeType ChangeType { get; set; }
        public DateOnly ChangeDate { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public int CreatorId { get; set; }
        public User Creator { get; set; } = new User();
        public string Reason { get; set; } = string.Empty;
    }
}
