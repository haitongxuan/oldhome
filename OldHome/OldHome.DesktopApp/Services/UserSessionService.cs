using OldHome.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Services
{
    public class UserSessionService : IUserSessionService
    {
        public string Username { get; private set; } = "";
        public string Token { get; private set; } = "";
        public string Role { get; private set; } = "";
        public int? OrgId { get; private set; } = null;
        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Token);
        public bool IsSuperAdmin => Role.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase);


        public event EventHandler<int>? OrgChanged;


        public void SetSession(string username, string token, string role, int OrgId)
        {
            Username = username;
            Token = token;
            Role = role;
            this.OrgId = OrgId;
        }

        public void ClearSession()
        {
            Username = "";
            Token = "";
            Role = "";
            OrgId = null;
        }

        public void ChangeOrgId(int orgId)
        {
            OrgId = orgId;
            OrgChanged?.Invoke(this, orgId);
        }
    }
}
