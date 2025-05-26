using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OldHome.DesktopApp.Converters
{
    public class Literal<T> : MarkupExtension
    {
        public T Value { get; }

        public Literal(T value)
        {
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
