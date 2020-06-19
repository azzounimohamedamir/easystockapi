using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetById;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class AreaItemViewModel
    {
        public AreaFilterViewModel AreaFilterViewModel { get; set; }
        public IEnumerable<AreaItemModel> Areas { get; set; }
    }

    public class AreaFilterViewModel
    {
        public SelectList Restaurants { get; set; }
        public SelectList Floors { get; set; }
        public string SelectedRestaurantId { get; set; }
        public string SelectedFloorId { get; set; }
    }
}
