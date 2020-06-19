using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Dishes
{
    public class DishIngredient:BaseEntity<Guid>
    {
        public Guid DishId { get; set; }  
        public Guid FoodId { get; set; }
        public bool IsPrincipal { get; set; }
        public Quantity Quantity { get; set; }        
        public bool IsSwitchable { get; set; }

        public Dish Dish { get; set; }

        public Food Food { get; set; }
    }
}