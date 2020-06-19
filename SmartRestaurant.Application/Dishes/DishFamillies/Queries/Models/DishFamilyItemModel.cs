using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Queries.Models
{
    public class DishFamilyItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RestaurantName { get; set; }
        public string ParentName { get; set; }
        public string PictureUrl { get; set; }
        public string SlugUrl { get; set; }
        public string IsDisabled { get; set; }
    }
}
