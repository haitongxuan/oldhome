using OldHome.API.Services;
using System.Net.Http.Headers;

namespace OldHome.Wasm
{
    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly IUserSessionService _userSession;

        public AuthorizationMessageHandler(IUserSessionService userSession)
        {
            _userSession = userSession;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // 添加JWT Token
            if (!string.IsNullOrWhiteSpace(_userSession.Token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _userSession.Token);
            }

            // 添加OrgId头
            if (_userSession.OrgId.HasValue)
            {
                request.Headers.Remove("OrgId");
                request.Headers.Add("OrgId", _userSession.OrgId.Value.ToString());
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
