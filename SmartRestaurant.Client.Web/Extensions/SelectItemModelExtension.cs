using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Select;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Extensions
{
    public static class SelectItemModelExtension
    {
        public static SelectList ToSelectList(this IEnumerable<SelectItemModel> items, string selectedValue = null)
        {
            return new SelectList(items, "Value", "Text", selectedValue);
        }

    }
}
