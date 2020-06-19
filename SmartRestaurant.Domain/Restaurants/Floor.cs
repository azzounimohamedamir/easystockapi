using SmartRestaurant.Domain.Commun;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Floor:BaseEntity<Guid>
    {
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
    }
}