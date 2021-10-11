using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class IngredientDto
    {
        public Guid IngredientId { get; set; }
        public List<IngredientNameDto> Names { get; set; }
        public string Picture { get; set; }
        public EnergeticValue EnergeticValue { get; set; }
    }
}