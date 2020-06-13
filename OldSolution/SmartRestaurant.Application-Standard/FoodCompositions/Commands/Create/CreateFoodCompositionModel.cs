using SmartRestaurant.Application.Foods.Commands.Create;
using System;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Create
{
    public class CreateFoodCompositionModel
    {
        public CreateQuantityModel Quantity { get; set; }
        public Guid FoodId { get; set; }
        public string Alis { get; set; }
       
    }
}