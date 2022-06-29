using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CriticalQteIllnessIngredientDto
    {
        public NamesDto IllnessName { get; set; }
        public float Quantity { get; set; }
    }
}
