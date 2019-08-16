using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class RestaurantRecommendation
    {
        public Guid RestaurantId { get; set; }
        public Guid RecommendationId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Recommendation Recommendation { get; set; }
    }
}