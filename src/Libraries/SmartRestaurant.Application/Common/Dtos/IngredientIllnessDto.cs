using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class IngredientIllnessDto
    {
        public string IngredientId { get; set; }
        public float Quantity { get; set; }
        public IngredientDto Ingredient { get; set; }
        public string IllnessId { get; set; }

    }
}
