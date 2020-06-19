using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetById;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class FloorItemViewModel
    {
        public FloorFilterViewModel FloorFilterViewModel { get; set; }
        public IEnumerable<FloorItemModel> Floors { get; set; }
    }

    public class FloorFilterViewModel
    {
        public SelectList Restaurants { get; set; }
        public string SelectedRestaurantId { get; set; }
    }
}
