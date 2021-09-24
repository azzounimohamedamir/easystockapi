using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class Dish : AuditableEntity
    {
        public Guid DishId { get; set; }
        public string Name { get; set; }
        public bool IsSupplement { get; set; }
        public Duration AveragePreparationTime { get; set; }
        public float PriceAmount { get; set; }

        public Guid? MenuId { get; set; }
        public Guid? SectionId { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}