using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MoviesServiceClient.WPF.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            else if (value is string)
            {
                Boolean.TryParse((string)value, out flag);
            }
            if (parameter != null)
            {
                bool bParam;
                if (bool.TryParse((string)parameter, out bParam) && bParam)
                {
                    flag = !flag;
                }
            }
            return flag 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var back = ((value is Visibility) && (((Visibility)value) == Visibility.Visible));
            if (parameter != null)
            {
                if ((bool)parameter)
                {
                    back = !back;
                }
            }
            return back;
        }
    }
}