using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MoviesServiceClient.WPF.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var invert = false;
            if (parameter != null)
            {
                Boolean.TryParse(parameter.ToString(), out invert);
            }
            if (value == null) return invert ? Visibility.Visible : Visibility.Collapsed;

            if (value is string)
                return string.IsNullOrWhiteSpace((string)value) || invert ? Visibility.Collapsed : Visibility.Visible;

            if (value is IList)
            {
                bool empty = ((IList)value).Count == 0;
                if (invert)
                    empty = !empty;
                if (empty)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }

            decimal number;
            if (Decimal.TryParse(value.ToString(), out number))
            {
                if (!invert)
                    return number > 0 ? Visibility.Visible : Visibility.Collapsed;
                    return number > 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}