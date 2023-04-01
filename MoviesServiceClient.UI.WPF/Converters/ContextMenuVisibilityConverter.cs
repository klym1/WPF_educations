using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MoviesServiceClient.WPF.Converters
{
    public class ContextMenuVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // var album = value as VkAudioAlbum;
            // if (album == null)
            return Visibility.Visible;

            // if (album.OwnerId != 0)
//            return Visibility.Visible;
//
//            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}