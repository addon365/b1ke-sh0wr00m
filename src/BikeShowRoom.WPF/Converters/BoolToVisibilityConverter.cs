using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BikeShowRoom.WPF.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            return (boolValue) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return Visibility.Visible;
        }
    }
}
