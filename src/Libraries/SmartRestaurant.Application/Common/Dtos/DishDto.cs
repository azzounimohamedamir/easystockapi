using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class DishDto
    {
        public Guid DishId { get; set; }
        public string Name { get; set; }
        public bool IsSupplement { get; set; }
        public DurationDto AveragePreparationTime { get; set; }
        public List<DishIngredientDto> DishIngredients { get; set; }
        public PriceDto Price { get; set; }
        public float TotalFat { get; set; }
        public float TotalProtein { get; set; }
        public float TotalCarbs { get; set; }
        public float TotalEnergy { get; set; }
    }
}