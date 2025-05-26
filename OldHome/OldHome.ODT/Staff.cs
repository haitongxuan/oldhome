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
    public class StaffDto : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Female;
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public string PhoneNumber { get; set; } = string.Empty;
        public StaffPosition Position { get; set; }
        [Display(Name = "入职日期")]
        public DateOnly HireDate { get; set; } = DateOnly.MinValue;
        public decimal Salary { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }

    public class StaffCreateDto : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Female;
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public string PhoneNumber { get; set; } = string.Empty;
        public StaffPosition Position { get; set; }
        [Display(Name = "入职日期")]
        public DateOnly HireDate { get; set; } = DateOnly.MinValue;
        public decimal Salary { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
        public int DepartmentId { get; set; }

    }

    public class StaffModifyDto : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Female;
        public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
        public string PhoneNumber { get; set; } = string.Empty;
        public StaffPosition Position { get; set; }
        [Display(Name = "入职日期")]
        public DateOnly HireDate { get; set; } = DateOnly.MinValue;
        public decimal Salary { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }

    public class StaffSample : BaseOrgByDto
    {
        public string Name { get; set; } = string.Empty;
    }
}