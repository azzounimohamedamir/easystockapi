using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class DishIngredient : AuditableEntity
    {
        public Guid DishIngredientId { get; set; }
        public bool IsPrimary { get; set; }
        public Quantity Quantity { get; set; }
        public Quantity AmountPerStep { get; set; }
        public float PricePerStep { get; set; }
        public Guid DishId { get; set; }
        public Guid IngredientId { get; set; }
    }
}