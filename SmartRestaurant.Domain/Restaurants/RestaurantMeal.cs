using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class RestaurantMeal
    {
        public Guid RestaurantId { get; set; }
        public Guid MealId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Meal Meal { get; set; }
    }
}