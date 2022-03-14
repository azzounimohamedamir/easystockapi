using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.ValueObjects
{
    public class OrderIngredientDto
    {
        public string IngredientId { get; set; }
        public List<IngredientNameDto> Names { get; set; }
        public EnergeticValueDto EnergeticValue { get; set; }     
    }
}
