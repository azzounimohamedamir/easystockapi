using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Extensions
{
    public static class EnumHelper<T> where T : Enum
    {
        public static SelectList ToSelectList( string someSelectedValue = null )          
        {
            
            var items = from T t in Enum.GetValues(typeof(T))
                              select new { Id = Convert.ToInt32(t), Name = t.ToString() };
            return  new SelectList(items, "Id", "Name", someSelectedValue);
        }

        public static SelectList ToLocalizedSelectList(string resource,CultureInfo culture,string SelectedValue = null)
        {
            
            ResourceManager rm = new ResourceManager($"SmartRestaurant.Resources.Enumerations.{resource}", Assembly.Load("SmartRestaurant.Resources"));

            var items = from T t in Enum.GetValues(typeof(T))
                        select new { Id = Convert.ToInt32(t), Name = rm.GetString(t.ToString(), culture) };
            return new SelectList(items, "Id", "Name", SelectedValue);
        }
    }
}
