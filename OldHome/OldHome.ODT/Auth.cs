using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public record SignInRequset(int OrgId, string UserName, string Password);

    public record SignInResponse(string Token, string UserName, string Role, int OrgId);

    public record ProfileResponse(string UserName, DateTime CreateAt, string PhoneNumber);

}
