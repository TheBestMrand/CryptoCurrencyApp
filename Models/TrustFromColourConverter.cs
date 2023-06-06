using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;


namespace CryptoCurrencyApp.Models
{
    public class TrustFromColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "green":
                    return Brushes.Green;
                case "yellow":
                    return Brushes.Yellow;
                case "red":
                    return Brushes.Red;
                default:
                    return Brushes.Gray;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
