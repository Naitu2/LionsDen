using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LionsDen.Converters
{
    internal class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isLoggedIn = (bool)value;
            if (isLoggedIn)
                return Brushes.DarkGray;
            else
                return Brushes.Blue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
