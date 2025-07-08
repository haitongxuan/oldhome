using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public record SignInRequset(int OrgId, string UserName, string Password);

    public record SignInResponse(string Token, string UserName, string Role, int OrgId, string? RefreshToken = null);


    public record ProfileResponse(string UserName, DateTime CreateAt, string PhoneNumber);

    // 请求和响应 DTO
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RevokeTokenRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
