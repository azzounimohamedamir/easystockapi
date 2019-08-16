using Helpers;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.Commands.Create
{
    public static class FoodFactory
    {
      
        public static Nutrition GetNutrition(this CreateNutritionModel model)
        {
            return new Nutrition(model.Quantity.GetQuantity(), model.GlycemicIndex,
                model.Fibre, model.Calorie, model.Protein, model.Carbohydrate, model.Lipid);
        }
        public static Quantity GetQuantity(this CreateQuantityModel model)
        {
            return new Quantity(model.UniteId, model.Value);
        }
    }
}
