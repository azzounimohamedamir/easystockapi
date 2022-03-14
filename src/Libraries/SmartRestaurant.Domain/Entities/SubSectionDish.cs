using System;

namespace SmartRestaurant.Domain.Entities
{
    public class SubSectionDish
    {
        public Guid SubSectionId { get; set; }
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }

    }
}
