using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class Meal : BaseEntity<Guid>
    {
        public ICollection<RestaurantMeal> RestaurantMeals { get; set; }
    }
}
