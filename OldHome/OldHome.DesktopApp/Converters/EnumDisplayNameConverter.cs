
using OldHome.DesktopApp.Utils;

namespace OldHome.DesktopApp.Converters
{
    public class EnumDisplayNameConverter : ValueConverterBase<object, string>
    {
        protected override string Convert(object value)
        {
            if (DesignMode.IsInDesignMode)
            {
                return null;
            }

            return EnumUtilities.GetDisplayName(value)!;
        }
    }
    public static class DesignMode
    {
        public static bool IsInDesignMode => false;
    }
}