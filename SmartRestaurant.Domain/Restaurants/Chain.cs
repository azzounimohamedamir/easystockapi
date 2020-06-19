using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Chain : BaseEntity<Guid>
    {
        public Guid OwnerId { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
        public Owner Owner { get; set; }
    }
}
