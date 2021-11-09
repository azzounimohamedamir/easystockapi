using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderDish : OrderMenuItem
    {
        public Guid OrderDishId { get; set; }
        public string DishId { get; set; }
        public int EstimatedPreparationTime { get; set; }
        public virtual IList<OrderDishSpecification> Specifications { get; set; }
        public virtual IList<OrderDishIngredient> Ingredients { get; set; }
        public virtual IList<OrderDishSupplement> Supplements { get; set; } 
    }
}