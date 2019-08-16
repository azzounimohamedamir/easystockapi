using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class RestaurantKitchen
    {
        public Guid RestaurantId { get; set; }
        public Guid KitchenId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Kitchen Kitchen { get; set; }
    }
}