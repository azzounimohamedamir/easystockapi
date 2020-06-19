using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class Kitchen : BaseEntity<Guid>
    {
        public ICollection<RestaurantKitchen> RestaurantKitchens { get; set; }
    }
}
