using Helpers;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using SmartRestaurant.Domain.Dishes;
using System;

namespace SmartRestaurant.Application.Dishes.DishIngredients.Commands.Factory
{
    public interface IDishIngredientFactory
    {
        DishIngredient Create(string name,
                              string alias,
                              string description,
                              bool isDisabled,
                              string foodId,
                              bool isPrincipal,
                              bool isSwitchable,
                              QuantityModel quantity);

        DishIngredient Create(DishIngredientModel model);
    }

    public class DishIngredientFactory : IDishIngredientFactory
    {
        private readonly IQuantityFactory quantityFactory;

        public DishIngredientFactory(IQuantityFactory quantityFactory)
        {
            this.quantityFactory = quantityFactory ?? throw new ArgumentNullException(nameof(quantityFactory));
        }
        public DishIngredient Create(string name,
                                     string alias,
                                     string description,
                                     bool isDisabled,
                                     string foodId,
                                     bool isPrincipal,
                                     bool isSwitchable,
                                     QuantityModel quantity)
        {
            return new DishIngredient
            {
                Name = name,
                Alias = alias,
                Description = description,
                IsDisabled = isDisabled,
                FoodId = foodId.ToGuid(),
                IsPrincipal = isPrincipal,
                IsSwitchable = isSwitchable,
                Quantity = quantityFactory.Create(quantity.UnitId, quantity.Value),
            };
        }

        public DishIngredient Create(DishIngredientModel model)
        {
            return Create(model.Name,
                          model.Alias,
                          model.Description,
                          model.IsDisabled,
                          model.FoodId,
                          model.IsPrincipal,
                          model.IsSwitchable,
                          model.Quantity);
        }
    }
}
