using OldHome.DesktopApp.Services;

namespace OldHome.DesktopApp.Messages
{
    public abstract class BaseMessage
    {
        protected IApiClient _apiClient;

        public BaseMessage()
        {
            _apiClient = ContainerLocator.Container.Resolve<IApiClient>();
        }
    }
}