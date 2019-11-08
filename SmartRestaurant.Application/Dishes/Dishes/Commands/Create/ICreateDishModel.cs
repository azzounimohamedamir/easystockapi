using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Create
{
    public interface ICreateDishModel
    {
        DishModel DishModel { get; set; }
        List<DishAccompanyingModel> Accompaniments { get; set; }
        List<DishEquivalenceModel> Equivalences { get; set; }
    }
}