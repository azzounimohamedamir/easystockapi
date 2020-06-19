using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class RestaurantRating : SmartRestaurantBaseEntity<Guid>
    {
        public Guid RestaurantId { get; set; }
        public string UserId { get; set; }
        public EnumRating Type { get; set; }
        public decimal Value { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
