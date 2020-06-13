using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using System;

namespace SmartRestaurant.Domain.Services
{
    public class ServiceDish:SmartRestaurantBaseEntity<Guid>
    {
        public Guid ServiceId { get; set; }

        public Service Service { get; set; }
        public Dish Dish { get; set; }

        //public Quantity Quantity { get; set; }
    }
}