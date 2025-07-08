using OldHome.API.Services;
using System.Timers;

namespace OldHome.Wasm.Services
{
    public class UserSessionService : IUserSessionService, IDisposable
    {
        private readonly System.Timers.Timer _sessionTimer;
        private const int DEFAULT_TIMEOUT_MINUTES = 60;
        private DateTime _lastActivityTime;

        public string Username { get; private set; } = "";
        public string Token { get; private set; } = "";
        public string Role { get; private set; } = "";
        public int? OrgId { get; private set; } = null;
        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Token);
        public bool IsSuperAdmin => Role.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase);

        public event EventHandler<int>? OrgChanged;
        public event EventHandler? SessionExpired;

        public UserSessionService()
        {
            _sessionTimer = new System.Timers.Timer(60000); // 检查间隔1分钟
            _sessionTimer.Elapsed += CheckSessionTimeout;
            UpdateLastActivity();
        }

        private void CheckSessionTimeout(object? sender, ElapsedEventArgs e)
        {
            if (IsAuthenticated && DateTime.Now.Subtract(_lastActivityTime).TotalMinutes >= DEFAULT_TIMEOUT_MINUTES)
            {
                ClearSession();
                SessionExpired?.Invoke(this, EventArgs.Empty);
            }
        }

        public void UpdateLastActivity()
        {
            _lastActivityTime = DateTime.Now;
        }

        public void SetSession(string username, string token, string role, int orgId)
        {
            Username = username;
            Token = token;
            Role = role;
            OrgId = orgId;

            UpdateLastActivity();
            _sessionTimer.Start();
        }

        public void ClearSession()
        {
            Username = "";
            Token = "";
            Role = "";
            OrgId = null;
            _sessionTimer.Stop();
        }

        public void ChangeOrgId(int orgId)
        {
            OrgId = orgId;
            UpdateLastActivity();
            OrgChanged?.Invoke(this, orgId);
        }

        public void Dispose()
        {
            _sessionTimer.Dispose();
        }
    }
}
