using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class DisheIllnessDto
    {
        public string IdDishe { get; set; }
        public List<IllnessIngredientCorrespondingDto> IllnessIngredients { get; set; }
    }
}
