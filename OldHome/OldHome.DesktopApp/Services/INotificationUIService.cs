using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Services
{
    public interface INotificationUIService
    {
        void ShowInformation(string message);
        void ShowSuccess(string message);
        void ShowWarning(string message);
        void ShowError(string message);
    }
}
