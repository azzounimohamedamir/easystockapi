using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class Feature : BaseEntity<Guid>
    {
        public ICollection<RestaurantFeature> RestaurantFeatures { get; set; }
    }
}
