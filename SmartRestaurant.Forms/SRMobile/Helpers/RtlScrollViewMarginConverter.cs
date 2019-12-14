using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Supplementes.Supplements;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.Helpers
{
    public class RtlScrollViewMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (AppResources.Culture.Name == "ar")
                return new Thickness(0, 0, 40, 0);
            return new Thickness(40, 0, 0, 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (AppResources.Culture.Name == "ar")
                return new Thickness(0, 0, 40, 0);
            return new Thickness(40, 0, 0, 0);
        }
    }
}
