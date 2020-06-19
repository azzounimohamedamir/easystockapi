using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace SmartRestaurant.Client.Web.Utils
{
    public static class SelectListHelper
    {
        public static SelectList PopulateEnum<T>(object selected = null) where T : Enum
        {

            var ActionTypes = from T t in Enum.GetValues(typeof(T))
                              select new { Id = Convert.ToInt32(t), Name = t.ToString() };
            return new SelectList(ActionTypes, "Id", "Name", selected);
        }
    }
}
