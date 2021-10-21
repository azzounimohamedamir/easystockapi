using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Dtos.DishDtos
{
    public class DishIngredientDto
    {
        public bool IsPrimary { get; set; }
        public float InitialAmount { get; set; }
        public float MinimumAmount { get; set; }
        public float MaximumAmount { get; set; }
        public float AmountIncreasePerStep { get; set; }
        public float PriceIncreasePerStep { get; set; }
        public MeasurementUnits MeasurementUnits { get; set; }
        public IngredientDto Ingredient { get; set; }
    }
}