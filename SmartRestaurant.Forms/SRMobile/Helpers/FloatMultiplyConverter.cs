using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Ingredientes.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.Helpers
{
        public class FloatMultiplyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
            int w = 0;
            int.TryParse(((Label)parameter).Text,out w);
            return (float)value * w;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int w = 0;
            int.TryParse(((Label)parameter).Text, out w);
            return (float)value * w;
        }
        }    
}
