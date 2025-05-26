using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;

namespace OldHome.DesktopApp.Converters
{
    public class Boolean2VisibilityConverter : ValueConverterBase<object, Visibility>
    {

        protected override Visibility Convert(object value)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public static class DesignMode
        {
            public static bool IsInDesignMode => false;
        }
    }
}
