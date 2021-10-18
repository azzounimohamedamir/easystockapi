using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.DishDtos
{
    public class DishDto
    {
        public Guid DishId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public Guid FoodBusinessId { get; set; }
        public List<DishSpecificationDto> Specifications { get; set; }
        public List<DishIngredientDto> Ingredients { get; set; }
        public List<DishSupplementDto> Supplements { get; set; }
        public bool IsSupplement { get; set; }
        public int EstimatedPreparationTime { get; set; }





        // public string Specifications { get; set; }
        //public bool IsSupplement { get; set; }
        //public DurationDto AveragePreparationTime { get; set; }
        //public List<DishIngredientDto> DishIngredients { get; set; }
        //public PriceDto Price { get; set; }
        //public float TotalFat { get; set; }
        //public float TotalProtein { get; set; }
        //public float TotalCarbs { get; set; }
        //public float TotalEnergy { get; set; }
    }
}