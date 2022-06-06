using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class IllnessDto
    {
        public Guid IllnessId { get; set; }
        public string Name { get; set; }
        public Names Names { get; set; }
        public List<IngredientIllnessDto> IngredientIllnesses { get; set; }
    }
}
