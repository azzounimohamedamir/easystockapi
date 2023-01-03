using SmartRestaurant.Application.Common.Dtos.DishDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class WarningIngredientOfOrderWithIllness
    {
        public string IngredientId { get; set; }
        public float Quantity { get; set; }
        public IngredientDto Ingredient { get; set; }
        public int MyProperty { get; set; }
        public List<DisheInSupplement> Dishes { get; set; }
        public List<CriticalQteIllnessIngredientDto> Illness { get; set; }
    }
    public class DisheInSupplement
    {
        public string IdDish { get; set; }
        public DishDto Dish { get; set; }
        public  bool InSuplement { get; set; }
    }
}
