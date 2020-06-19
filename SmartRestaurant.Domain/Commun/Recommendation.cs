using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class Recommendation : BaseEntity<Guid>
    {
        public ICollection<RestaurantRecommendation> RestaurantRecommendations { get; set; }
    }
}
