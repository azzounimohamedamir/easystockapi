using System;
using System.Collections.ObjectModel;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class IngredientDto
    {
        public Guid IngredientId { get; set; }
        public Collection<IngredientNameDto> Names { get; set; }
        public string Picture { get; set; }
        public EnergeticValue EnergeticValue { get; set; }
    }
}