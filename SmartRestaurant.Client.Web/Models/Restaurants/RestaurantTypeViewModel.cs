using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class RestaurantTypeViewModel
    {
        public RestaurantTypeViewModel()
        {

        }
        public UpdateRestaurantTypeModel UpdateModel { get; set; }
        public CreateRestaurantTypeModel CreateModel { get; set; }
    }
}
