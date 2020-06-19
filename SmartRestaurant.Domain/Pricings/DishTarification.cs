using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Pricings
{
    public class DishTarification : SmartRestaurantBaseEntity<Guid>
    {
        public Dish Dish { get; set; }
        public Tarification Tarification { get; set; }

        public Guid DishId { get; set; }
        public Guid TarificationId { get; set; }
    }
}
