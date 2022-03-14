using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderDishIngredientDto
    {
        public bool IsPrimary { get; set; }
        public float Amount { get; set; }
        public float MinimumAmount { get; set; }
        public float MaximumAmount { get; set; }
        public float AmountIncreasePerStep { get; set; }
        public float PriceIncreasePerStep { get; set; }
        public MeasurementUnits MeasurementUnits { get; set; }
        public int Steps { get; set; }
        public OrderIngredientDto OrderIngredient { get; set; }
    }
}
