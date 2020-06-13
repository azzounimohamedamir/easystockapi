using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class DishFamilyFilterViewModel
    {
        public string Name { get; set; }
        public SelectList Parents { get; set; }
        public string ParentId { get; set; }
        public SelectList Restaurants { get; set; }
        public string RestaurantId { get; set; }

        public bool HasValue
        {
            get
            {
                if (this == null) return false;
                if (string.IsNullOrEmpty(Name)
                    && string.IsNullOrEmpty(ParentId)
                    && string.IsNullOrEmpty(RestaurantId)) return false;
                return true;
            }
            
        }
    }
}
