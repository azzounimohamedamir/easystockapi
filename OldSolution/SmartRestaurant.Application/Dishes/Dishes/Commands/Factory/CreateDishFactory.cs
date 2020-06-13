using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Factory;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Factory
{
    public interface ICreateDishFactory
    {
        
        Dish Create(DishModel dishModel,
                    List<DishIngredientModel> ingredients,
                    List<DishAccompanyingModel> accompaniments,
                    List<DishEquivalenceModel> equivalences);
    }
    public class CreateDishFactory : ICreateDishFactory
    {
        private readonly IDishFactory dishFactory;
        private readonly IDishIngredientFactory dishIngredientFactory;
        private readonly IDishAccompanyingFactory dishAccompanyingFactory;
        private readonly IDishEquivalenceFactory dishEquivalenceFactory;
        private readonly IGalleryFactory galleryFactory;

        public CreateDishFactory(
            IDishFactory dishFactory,
            IDishIngredientFactory dishIngredientFactory,
            IDishAccompanyingFactory dishAccompanyingFactory,
            IDishEquivalenceFactory dishEquivalenceFactory,
            IGalleryFactory galleryFactory)
        {            
            this.dishFactory = dishFactory ?? throw new ArgumentNullException(nameof(dishFactory));
            this.dishIngredientFactory = dishIngredientFactory ?? throw new ArgumentNullException(nameof(dishIngredientFactory));
            this.dishAccompanyingFactory = dishAccompanyingFactory ?? throw new ArgumentNullException(nameof(dishAccompanyingFactory));
            this.dishEquivalenceFactory = dishEquivalenceFactory ?? throw new ArgumentNullException(nameof(dishEquivalenceFactory));
            this.galleryFactory = galleryFactory ?? throw new ArgumentNullException(nameof(galleryFactory));
        }       
               

        public Dish Create(DishModel dishModel,
                            List<DishIngredientModel> ingredients,
                            List<DishAccompanyingModel> accompaniments,
                            List<DishEquivalenceModel> equivalences)
        {
            Dish dish = dishFactory.Create(dishModel);
            if (ingredients != null && ingredients.Any())
            {
                dish.Ingredients = new List<DishIngredient>();
                foreach (var ingredient in ingredients)
                {
                    dish.Ingredients.Add(dishIngredientFactory.Create(ingredient));
                }
            }
            if (accompaniments != null && accompaniments.Any())
            {
                dish.ChildAccompaniments = new List<DishAccompanying>();
                foreach (var accompaniment in accompaniments)
                {
                    dish.ChildAccompaniments.Add(dishAccompanyingFactory.Create(accompaniment));
                }
            }
            if (equivalences != null && equivalences.Any())
            {
                dish.ChildEquivalences = new List<DishEquivalence>();
                foreach (var equivalence in equivalences)
                {
                    dish.ChildEquivalences.Add(dishEquivalenceFactory.Create(equivalence));
                }
            }
            
            return dish;
        }
    }
}
