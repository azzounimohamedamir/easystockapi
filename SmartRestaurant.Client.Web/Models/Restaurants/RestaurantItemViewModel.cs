using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class RestaurantItemViewModel
    {
        public SelectList RestaurantTypes { get; set; }
        public SelectList Chains { get; set; }
        public SelectList Owners { get; set; }

        public string SelectedRestaurantTypeId { get; set; }
        public string SelectedChainId { get; set; }
        public string SelectedOwnerId { get; set; }
        public IEnumerable<RestaurantItemModel> Entities { get; set; }
    }
}
