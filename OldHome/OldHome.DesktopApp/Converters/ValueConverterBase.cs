using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace OldHome.DesktopApp.Converters
{
    public abstract class ValueConverterBase<TValue, TResult> : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Convert(default);
            }

            TValue value2;
            if (value is TValue)
            {
                value2 = (TValue)value;
            }
            else
            {
                if (DesignMode.IsInDesignMode)
                {
                    if (typeof(TResult) == typeof(string))
                    {
                        return value.ToString();
                    }

                    return null;
                }

                if (!Equals(value, default(TValue)))
                {
                    throw new ArgumentException("Converted value type is unsupported", "value");
                }

                value2 = default;
            }

            return Convert(value2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return ConvertBack(default);
            }

            TResult value2;
            if (value is TResult)
            {
                value2 = (TResult)value;
            }
            else
            {
                if (!Equals(value, default(TResult)))
                {
                    throw new ArgumentException("value");
                }

                value2 = default;
            }

            return ConvertBack(value2);
        }

        protected abstract TResult Convert(TValue value);

        protected virtual TValue ConvertBack(TResult value)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}