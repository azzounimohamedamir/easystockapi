using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.FoodCompositions.Commands.Models;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Models;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Create
{
    public interface ICreateFoodCompositionModel
    {
        IFoodCompositionModel Composition { get; set; }
    }
}