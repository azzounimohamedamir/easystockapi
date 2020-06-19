using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Dishes.DishIngredients.Commands.Factory
{
    public interface IDishIngredientModelFactory
    {
        DishIngredientModel Create(
                                string id,
                                string name,
                                string alias,
                                string description,
                                bool isDisabled,
                                string foodId,
                                string foodCategoryId,
                                string foodUnitId,
                                bool isPrincipal,
                                bool isSwitchable,
                                QuantityModel quantity);

        DishIngredientModel Create(DishIngredient model);

        IEnumerable<DishIngredientModel> Create(IEnumerable<DishIngredient> entities);
    }

    public class DishIngredientModelFactory : IDishIngredientModelFactory
    {
        private readonly IQuantityModelFactory quantityModelFactory;

        public DishIngredientModelFactory(IQuantityModelFactory quantityModelFactory)
        {
            this.quantityModelFactory = quantityModelFactory ?? throw new ArgumentNullException(nameof(quantityModelFactory));
        }

        private List<string> AddParentsIds(FoodCategory category, List<string> parentsIds)
        {
            if (category.Parent != null)
            {
                parentsIds.Insert(0, category.Parent.Id.ToString());
                AddParentsIds(category.Parent, parentsIds);
            }
            else
            {
                parentsIds.Add(category.Id.ToString());
            }
            return parentsIds;
        }

        public DishIngredientModel Create(DishIngredient entity)
        {
            DishIngredientModel ingredient = new DishIngredientModel();

            ingredient = Create(
                entity.Id.ToString(),
                entity.Name,
                entity.Alias,
                entity.Description,
                entity.IsDisabled,
                entity.FoodId.ToString(),
                entity.Food.FoodCategoryId.ToString(),
                entity.Food.UnitId.ToString(),
                entity.IsPrincipal,
                entity.IsSwitchable,
                quantityModelFactory.Create(entity.Quantity.UnitId, entity.Quantity.Value));

            AddParentsIds(entity.Food.Category, ingredient.FoodCategoryParentsIds);
            return ingredient;
        }


        public DishIngredientModel Create(string id,
                                          string name,
                                          string alias,
                                          string description,
                                          bool isDisabled,
                                          string foodId,
                                          string foodCategoryId,
                                          string foodUnitId,
                                          bool isPrincipal,
                                          bool isSwitchable,
                                          QuantityModel quantity)
        => new DishIngredientModel
        {
            Id = id,
            Name = name,
            Alias = alias,
            Description = description,
            IsDisabled = isDisabled,
            FoodId = foodId,
            FoodCategoryId = foodCategoryId,
            FoodUnitId = foodUnitId,
            IsPrincipal = isPrincipal,
            IsSwitchable = isSwitchable,
            Quantity = quantity,
        };


        public IEnumerable<DishIngredientModel> Create(IEnumerable<DishIngredient> entities)
        => (from entity in entities select Create(entity)).AsEnumerable();
    }
}
