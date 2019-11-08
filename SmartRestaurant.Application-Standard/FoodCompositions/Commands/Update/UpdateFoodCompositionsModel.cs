using SmartRestaurant.Application.FoodCompositions.Commands.Create;
using System;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Update
{
    public class UpdateFoodCompositionsModel: CreateFoodCompositionModel
    {
        public Guid  Id { get; set; }
    }
}