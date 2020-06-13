using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class RestaurantPriceType
    {
        public Guid RestaurantId { get; set; }
        public Guid PriceTypeId { get; set; }
        public Restaurant Restaurant { get; set; }
        public PriceType PriceType { get; set; }
    }
}