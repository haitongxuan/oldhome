using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class ResidentEmergencyContactDto
    {
        public int Id { get; set; }
        public int ResidentId { get; set; }
        public ResidentDto Resident { get; set; } = new ResidentDto();
        public int EmergencyContactId { get; set; }
        public EmergencyContactDto EmergencyContact { get; set; } = new EmergencyContactDto();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ContactRelationship Relationship { get; set; } = ContactRelationship.Child;
    }
    public class ResidentEmergencyContactCreate
    {
        public int ResidentId { get; set; }
        public int EmergencyContactId { get; set; }
        public ContactRelationship Relationship { get; set; } = ContactRelationship.Child;
    }
    public class ResidentEmergencyContactModify : BaseOrgByDto
    {
        public int ResidentId { get; set; }
        public int EmergencyContactId { get; set; }
        public ContactRelationship Relationship { get; set; } = ContactRelationship.Child;
    }
}
