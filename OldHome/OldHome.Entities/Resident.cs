using OldHome.Core;
using OldHome.Core.Attributes;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Resident : BaseOrgByEntity
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        [SerialNumber("RESIDENT", Prefix = "R", ResetDaily = false)]
        public string? Code { get; set; }
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public string IdCardNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly AdmissionDate { get; set; } = DateOnly.MinValue;
        public int OrgAreaId { get; set; }
        public OrgArea OrgArea { get; set; }
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public string HealthDescription { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public List<EmergencyContact> EmergencyContacts { get; set; }
    }
}
