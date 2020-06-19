using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Update
{
    public class UpdateDishModel
    {
        public string Id { get; set; }
        public DishModel DishModel { get; set; }
        public List<DishIngredientModel> Ingredients { get; set; }
        public List<DishAccompanyingModel> Accompaniments { get; set; }
        public List<DishEquivalenceModel> Equivalences { get; set; }
        public GalleryModel Gallery { get; set; }
    }
}
