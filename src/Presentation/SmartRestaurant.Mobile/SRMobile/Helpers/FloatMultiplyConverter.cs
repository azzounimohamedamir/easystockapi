using System;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.Helpers
{
    public class FloatMultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float w = 0;
            try
            {
                float.TryParse(((Label)parameter).Text, out w);
            }
            catch
            {
                //item height
                w = 250;
            }
            return (float)value * w;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float w = 0;
            try
            {
                float.TryParse(((Label)parameter).Text, out w);
            }
            catch
            {
                w = 250;
            }
            return (float)value * w;
        }
    }
}
