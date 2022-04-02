using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class DishIllnessDto
    {
        public string IdDishe { get; set; }
        public List<IllnessIngredientCorrespondingDto> IllnessIngredients { get; set; }
    }
}
