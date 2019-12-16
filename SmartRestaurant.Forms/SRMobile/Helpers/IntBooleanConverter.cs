using SmartRestaurant.Diner.Resources;
using System;

using Xamarin.Forms;

namespace SmartRestaurant.Diner.Helpers
{

    public class IntBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((int)value == 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((int)value == 0);
        }
    }
    public class CultureBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return AppResources.Culture.Name == "ar";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return AppResources.Culture.Name == "ar";
        }
    }

}