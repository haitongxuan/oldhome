using OldHome.API.Services;

namespace OldHome.API
{
    public abstract class BaseMessage
    {
        protected IApiClient _apiClient;

        public BaseMessage(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}