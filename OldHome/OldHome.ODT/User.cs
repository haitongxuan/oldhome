using OldHome.DTO.Base;

namespace OldHome.DTO
{
    public class UserDto : BaseOrgByDto
    {
        public string UserName { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string OrgName { get; set; } = string.Empty;
        public int RoleId { get; set; } = 0;
        public DateTime CreateAt { get; set; }
    }


    public class UserCreate : BaseOrgByDto
    {
        public string UserName { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }

    public class UserModify : BaseOrgByDto
    {
        public string PhoneNum { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
