using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Domain.Dishes
{
    public class Ingredient:BaseEntity<Guid>
    {
        public Guid RestaurantId { get; set; }
        public Guid UnitId { get; set; }
        public Guid? PictureId { get; set; } 
        public Unit Unit { get; set; }
        public ICollection<Food> Foods { get; set; }
        public Picture Picture { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<DishIngredient> Ingredients { get; set; }
    }
}