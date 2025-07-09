using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class OrgCreate : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;

    }

    public class OrgModify : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
    }

    public class OrgDto : BaseDto
    {
        [Display(Name = "名称")]
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "地址")]
        public string Address { get; set; } = string.Empty;
        [Display(Name = "电话")]
        [Required(ErrorMessage = "电话不能为空")]
        public string PhoneNum { get; set; } = string.Empty;
        [Display(Name = "是否总公司")]
        public bool IsHead { get; set; }
        public List<OrgAreaDto> OrgAreas { get; set; } = new List<OrgAreaDto>();
    }

    public class OrgSample : BaseDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
