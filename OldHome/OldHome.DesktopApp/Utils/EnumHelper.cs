using System.ComponentModel.DataAnnotations;

namespace OldHome.DesktopApp.Utils
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获得枚举的displayName
        /// </summary>
        /// <param name="eum"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum eum)
        {
            return EnumUtilities.GetDisplayName(eum) ?? "";
        }

        public static ConfigKeyAttribute? GetConfigKey(this Enum value)
        {
            Type type = value.GetType();
            object[] customAttributes = type.GetMember(value.ToString())[0].GetCustomAttributes(typeof(ConfigKeyAttribute), inherit: false);
            if (customAttributes.Length == 0)
            {
                return (ConfigKeyAttribute)customAttributes[0];
            }
            return (ConfigKeyAttribute)customAttributes[0];
        }
    }
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
    public class ConfigKeyAttribute : Attribute
    {
        public string Key { get; set; }

        public ConfigKeyAttribute(string key)
        {
            Key = key;
        }
    }
}
