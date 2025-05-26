using Panuon.WPF.UI;
using Panuon.WPF.UI.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OldHome.DesktopApp.Services
{
    internal class NotificationUIService : INotificationUIService
    {
        public void ShowError(string message)
        {
            var setting = Application.Current.FindResource("errorToast") as ToastSetting;
            Toast.Show(Application.Current.MainWindow as WindowX, message, MessageBoxIcon.Error, ToastPosition.Bottom, 0, 3000, setting);
        }

        public void ShowInformation(string message)
        {
            var setting = Application.Current.FindResource("informationToast") as ToastSetting;
            Toast.Show(Application.Current.MainWindow as WindowX, message, MessageBoxIcon.Info, ToastPosition.Bottom, 0, 3000, setting);
        }

        public void ShowSuccess(string message)
        {
            var setting = Application.Current.FindResource("successToast") as ToastSetting;
            Toast.Show(Application.Current.MainWindow as WindowX, message, MessageBoxIcon.Success, ToastPosition.Bottom, 0, 3000, setting);
        }

        public void ShowWarning(string message)
        {
            var setting = Application.Current.FindResource("warnToast") as ToastSetting;
            Toast.Show(Application.Current.MainWindow as WindowX, message, MessageBoxIcon.Warning, ToastPosition.Bottom, 0, 3000, setting);
        }
    }
}
