using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetById;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class PlaceItemViewModel
    {
        public FilterViewModel Filter { get; set; }
        public IEnumerable<PlaceItemModel> Places { get; set; }
    }

    public class FilterViewModel
    {
        public SelectList Restaurants { get; set; }
        public SelectList Floors { get; set; }
        public SelectList Areas { get; set; }
        public SelectList Tables { get; set; }
        public string SelectedRestaurantId { get; set; }
        public string SelectedFloorId { get; set; }
        public string SelectedAreaId { get; set; }
        public string SelectedTableId { get; set; }
    }
}


