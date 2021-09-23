using System;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.Entities
{
    public class Specification : AuditableEntity
    {
        public Guid SpecificationId { get; set; }
        public string Name { get; set; }

        public Guid DishId { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}