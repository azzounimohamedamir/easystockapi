using System;

namespace SmartRestaurant.Domain.Entities
{
    public class DishSupplement
    {
        public Guid SupplementId { get; set; }
        public virtual Dish Supplement { get; set; }
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
