using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class RestaurantViewModel
    {
        public RestaurantViewModel()
        {

        }
        public SelectList Owners { get; set; }
        public SelectList Chains { get; set; }
        public SelectList RestaurantTypes { get; set; }
        public UpdateRestaurantModel UpdateModel { get; set; }
        public CreateRestaurantModel CreateModel { get; set; }
    }
}
