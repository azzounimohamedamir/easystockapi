using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class RestaurantType : BaseEntity<Guid>
    {
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}