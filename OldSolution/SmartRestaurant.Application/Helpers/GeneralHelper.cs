using SmartRestaurant.Resources.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Helpers
{
    public static class GeneralHelper
    {
        public static string DisabledDisplay(this bool isDisabled)
        {
            return !isDisabled ? UtilsResource.IsDisabledFalseValueText :UtilsResource.IsDisabledTrueValueText;
        }

        public static string ToText(this bool isDisabled)
        {
            return !isDisabled ? UtilsResource.IsDisabledFalseValueText : UtilsResource.IsDisabledTrueValueText;
        }

        public static string EnumValueToText<T>(this T enumValue, string resource)
        {
            var culture = new CultureInfo("fr-FR");
            ResourceManager rm = new ResourceManager($"SmartRestaurant.Resources.Enumerations.{resource}", Assembly.Load("SmartRestaurant.Resources"));

            var value = (from T t in Enum.GetValues(typeof(T))
                         where t.Equals(enumValue)
                         select rm.GetString(t.ToString(), culture)).Single();

            return value;
        }
        public static string EnumValueToText<T>(this T enumValue, string resource, CultureInfo culture)
        {
            ResourceManager rm = new ResourceManager($"SmartRestaurant.Resources.Enumerations.{resource}", Assembly.Load("SmartRestaurant.Resources"));

            var value = (from T t in Enum.GetValues(typeof(T)) where t.Equals(enumValue)
                        select rm.GetString(t.ToString(), culture)).Single() ;
            return value;
        }
    }
}
