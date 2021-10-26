using System;

namespace SmartRestaurant.Domain.Entities
{
    public class SectionDish
    {
        public Guid SectionId { get; set; }
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }

    }
}
