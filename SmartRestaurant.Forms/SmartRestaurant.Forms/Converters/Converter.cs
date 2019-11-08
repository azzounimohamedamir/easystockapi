using SmartRestaurant.Resources.Xamarin.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SmartRestaurant.Forms.Converters
{ 
        [Preserve(AllMembers = true)]

        public class InverseZeroVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is int && (int)value > 0)
                    return true;
                return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        [Preserve(AllMembers = true)]
        public class ZeroVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is int && (int)value <= 0)
                    return true;
                return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        [Preserve(AllMembers = true)]
        public class TotalItemsCountConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is int && (int)value <= 1)
                    return $" | {value} {UIRes.ItemTxt} | ";
                return $" | {value} {UIRes.ItemsTxt} | ";
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        [Preserve(AllMembers = true)]
        public class CurrencyFormatConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var d = value;
                return string.Format("{0:0.00}", d);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

