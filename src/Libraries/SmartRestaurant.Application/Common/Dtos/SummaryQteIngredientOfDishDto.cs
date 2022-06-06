using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class SummaryQteIngredientOfDishDto
    {
        public string IdDish { get; set; }
        public float QteDish { get; set; }
        public List<SummaryQteIngredientDto> IngredientDishes { get; set; }
        public List<string> IdSupplement { get; set; }
    }
}
