using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Services
{
    public interface IUserSessionService
    {
        string Username { get; }
        string Token { get; }
        string Role { get; }
        int? OrgId { get; }
        bool IsAuthenticated { get; }
        bool IsSuperAdmin { get; }

        void SetSession(string username, string token, string role, int orgId);
        void ChangeOrgId(int orgId);
        void ClearSession();
    }
}
