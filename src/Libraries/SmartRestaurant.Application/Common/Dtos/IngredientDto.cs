using System;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class IngredientDto
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Energy { get; set; }
        public Quantity MinQuantity { get; set; }
        public Quantity MaxQuantity { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}