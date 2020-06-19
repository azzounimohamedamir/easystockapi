using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Foods
{
    public class FoodComposition: SmartRestaurantBaseEntity<Guid>
    {
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
        public Quantity Quantity { get; set; }


    }
}