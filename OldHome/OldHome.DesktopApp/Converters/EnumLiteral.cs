using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OldHome.DesktopApp.Converters
{
    public class EnumLiteral : MarkupExtension
    {
        public object EnumValue { get; }

        public EnumLiteral(Type enumType, string enumString)
        {
            if (!Enum.TryParse(enumType, enumString, out var result))
            {
                throw new ArgumentException("'" + enumString + "' is not a valid " + enumType.Name + " value");
            }

            EnumValue = result;
        }

        public EnumLiteral(object enumValue)
        {
            EnumValue = enumValue;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return EnumValue;
        }
    }
}
