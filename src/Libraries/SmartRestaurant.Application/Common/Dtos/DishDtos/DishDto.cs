using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.DishDtos
{
    public class DishDto
    {
        public Guid DishId { get; set; }
        public string Name { get; set; }
        public NamesDto Names { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public Guid FoodBusinessId { get; set; }
        public List<DishSpecificationDto> Specifications { get; set; }
        public List<DishIngredientDto> Ingredients { get; set; }
        public List<DishSupplementDto> Supplements { get; set; }
        public bool IsSupplement { get; set; }
        public int Quantity { get; set; }
        public bool IsQuantityChecked { get; set; } 
        public int EstimatedPreparationTime { get; set; }
        public List<CurrencyDto> CurrencyExchange { get; set; }
        public bool SyncFromOdoo { get; set; }
    }
}