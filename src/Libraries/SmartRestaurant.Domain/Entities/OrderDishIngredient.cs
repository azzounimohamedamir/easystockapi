using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderDishIngredient
    {
        public Guid OrderDishIngredientId { get; set; }
        public bool IsPrimary { get; set; }
        public float Amount { get; set; }
        public float InitAmount { get; set; }

        public float MinimumAmount { get; set; }
        public float MaximumAmount { get; set; }
        public float AmountIncreasePerStep { get; set; }
        public float PriceIncreasePerStep { get; set; }
        public MeasurementUnits MeasurementUnits { get; set; }
        public int Steps { get; set; }
        public OrderIngredient OrderIngredient { get; set; }
        public Guid OrderDishId { get; set; }
    }
}