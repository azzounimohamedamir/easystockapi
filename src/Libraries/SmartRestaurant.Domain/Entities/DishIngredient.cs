using System;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class DishIngredient
    {
        public bool IsPrimary { get; set; }
        public float InitialAmount { get; set; }
        public float MinimumAmount { get; set; }
        public float MaximumAmount { get; set; }
        public float AmountIncreasePerStep { get; set; }
        public float PriceIncreasePerStep { get; set; }
        public MeasurementUnits MeasurementUnits { get; set; }
        public Guid DishId { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}