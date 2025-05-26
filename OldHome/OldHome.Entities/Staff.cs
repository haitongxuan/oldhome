using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Staff : BaseOrgByEntity
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Female;
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public string PhoneNumber { get; set; } = string.Empty;
        public StaffPosition Position { get; set; }
        public DateOnly HireDate { get; set; } = DateOnly.MinValue;
        public DateOnly LeaveDate { get; set; } = DateOnly.MinValue;
        public decimal Salary { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } 
        public string Photo { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
