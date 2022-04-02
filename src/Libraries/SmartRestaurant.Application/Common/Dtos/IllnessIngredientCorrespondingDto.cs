using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class IllnessIngredientCorrespondingDto
    {
        public string IngredientId { get; set; }
        public List<IllnessDto> Illness { get; set; }
    }
}