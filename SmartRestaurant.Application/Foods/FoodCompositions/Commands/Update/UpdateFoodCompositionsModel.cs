using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.FoodCompositions.Commands.Create;
using SmartRestaurant.Application.FoodCompositions.Commands.Models;
using System;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Update
{
    public class UpdateFoodCompositionsModel:IFoodCompositionModel
    {
        public string Alias { get; set; }
        public string FoodId { get; set; }
        public string Id { get; set; }
        public QuantityModel Quantity { get; set; }        
    }
}