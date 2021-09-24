using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class DishIngredientDto
    {
        public Guid DishIngredientId { get; set; }
        public string IngredientName { get; set; }
        public bool IsPrimary { get; set; }
        public QuantityDto Quantity { get; set; }
        public QuantityDto AmountPerStep { get; set; }
        public float PricePerStep { get; set; }
        public Guid IngredientId { get; set; }
    }
}