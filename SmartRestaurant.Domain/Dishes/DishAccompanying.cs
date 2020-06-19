using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Dishes
{
    public class DishAccompanying : SmartRestaurantEntity
    {
        public Guid ParentId { get; set; }
        public Dish Parent { get; set; }

        public Guid AccompanyingId { get; set; }
        public Dish Accompanying { get; set; }


        public Quantity Quantity { get; set; }


    }
}
