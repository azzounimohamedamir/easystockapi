using Helpers;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Domain.Commun;


namespace SmartRestaurant.Application.Foods.Commands.Create
{
    public static class FoodFactory
    {
      
        public static Nutrition GetNutrition(this NutritionModel model)
        {
            return new Nutrition(model.Quantity.ToVOQuantity(), model.GlycemicIndex,
                model.Fibre, model.Calorie, model.Protein, model.Carbohydrate, model.Lipid);
        }
        public static Quantity ToVOQuantity(this QuantityModel model)
        {
            return new Quantity(model.UnitId.ToGuid(), model.Value);
        }
    }
}
