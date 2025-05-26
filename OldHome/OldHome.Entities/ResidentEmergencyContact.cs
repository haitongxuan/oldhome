using OldHome.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class ResidentEmergencyContact
    {
        public int Id { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();
        public int EmergencyContactId { get; set; }
        public EmergencyContact EmergencyContact { get; set; } = new EmergencyContact();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ContactRelationship Relationship { get; set; } = ContactRelationship.Child;
    }
}
