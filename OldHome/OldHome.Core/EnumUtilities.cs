using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Core
{
    public static class EnumUtilities
    {
        public static string? GetDisplayName(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Type type = value.GetType();
            if (!type.IsEnum)
            {
                return null;
            }

            object[] customAttributes = type.GetMember(value.ToString())[0].GetCustomAttributes(typeof(DisplayAttribute), inherit: false);
            if (customAttributes.Length == 0)
            {
                return value.ToString();
            }

            return ((DisplayAttribute)customAttributes[0]).Name;
        }
    }
}
