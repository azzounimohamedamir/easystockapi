using System;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.Helpers
{
    public class IntMultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int w = 0;
            try
            {
                int.TryParse(((Label)parameter).Text, out w);
            }
            catch
            {
                //item height
                w = 250;
            }
            return (int)value * w;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int w = 0;
            try
            {
                int.TryParse(((Label)parameter).Text, out w);
            }
            catch
            {
                w = 250;
            }
            return (int)value * w;
        }
    }
}
