using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class ResidentDto : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public int Age { get; set; }
        public string IdCardNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly AdmissionDate { get; set; } = DateOnly.MinValue;
        public int OrgAreaId { get; set; }
        public string OrgAreaName { get; set; } = string.Empty;
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int BedId { get; set; }
        public string BedNumber { get; set; } = string.Empty;
        public HealthStatus HealthStatus { get; set; }
        public string HealthDescription { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public List<ResidentEmergencyContactDto> ResidentEmergencyContactDtos { get; set; } = new List<ResidentEmergencyContactDto>();
    }

    public class ResidentCreate : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public string IdCardNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly AdmissionDate { get; set; } = DateOnly.MinValue;
        public int OrgAreaId { get; set; }
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public int BedId { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string HealthDescription { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }

    public class ResidentModify : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public string IdCardNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly AdmissionDate { get; set; } = DateOnly.MinValue;
        public int OrgAreaId { get; set; }
        public int Floor { get; set; }
        public int RoomId { get; set; }
        public int BedId { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string HealthDescription { get; set; } = string.Empty;
    }

    public class ResidentSample : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
