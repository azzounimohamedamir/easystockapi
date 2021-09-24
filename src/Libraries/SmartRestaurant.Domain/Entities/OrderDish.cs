using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderDish : AuditableEntity
    {
        public Guid OrderDishId { get; set; }
        public string Name { get; set; }
        public float PriceValue { get; set; }
        public List<OrderDishIngredient> OrderDishIngredients { get; set; }
    }
}