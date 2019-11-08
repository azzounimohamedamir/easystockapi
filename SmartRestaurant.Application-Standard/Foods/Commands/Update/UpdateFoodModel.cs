using SmartRestaurant.Application.Foods.Commands.Create;
using System;

namespace SmartRestaurant.Application.Foods.Commands.Update
{
    public class UpdateFoodModel:CreateFoodModel
    {
        public Guid  Id { get; set; }
    }
}