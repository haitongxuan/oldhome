using OldHome.DesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OldHome.DesktopApp.Converters
{
    public class FormStateToVisibilityConverter : ValueConverterBase<FormState, Visibility>
    {
        protected override Visibility Convert(FormState value)
        {
            return value.Equals(FormState.View) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
