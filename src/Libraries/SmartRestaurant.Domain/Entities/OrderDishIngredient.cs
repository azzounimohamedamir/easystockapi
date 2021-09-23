using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderDishIngredient : AuditableEntity
    {
        public Guid OrderDishIngredientId { get; set; }
        public string Name { get; set; }
        public Quantity QuantityPerStep { get; set; }
        public float PriceValuePerStep { get; set; }
        public int Steps { get; set; }
    }
}