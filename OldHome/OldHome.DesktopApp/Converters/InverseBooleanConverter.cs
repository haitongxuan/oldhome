using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OldHome.DesktopApp.Converters
{
    public class InverseBooleanConverter : ValueConverterBase<object, bool>
    {
        protected override bool Convert(object value)
        {
            var res = !(bool)value;
            return res;
        }
    }
}
