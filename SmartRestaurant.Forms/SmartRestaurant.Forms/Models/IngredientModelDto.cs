using SmartRestaurant.Application.Services.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Forms.Models
{
    public class IngredientModelDto : BaseModel
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public bool IsPrincipal { get; set; }
        public bool IsSwitchable { get; set; }

        public IngredientQuantityModelDto Quantity { get; set; }//Unit, value
        public IngredientNutritionModelDto Nutrition { get; set; }


        public static implicit operator IngredientModelDto(IngredientModel model)
        {
            if (model == null) return null;
            return new IngredientModelDto
            {
                Id =model.Id,
                ImageUrl= model.ImageUrl,
                IsPrincipal= model.IsPrincipal,
                IsSwitchable = model.IsSwitchable,
                Name= model.Name,
                Nutrition = model.Nutrition,
                Quantity= model.Quantity
            };
        }
        public static implicit operator IngredientModel(IngredientModelDto model)
        {
            if (model == null) return null;
            return new IngredientModel
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                IsPrincipal = model.IsPrincipal,
                IsSwitchable = model.IsSwitchable,
                Name = model.Name,
                Nutrition = model.Nutrition,
                Quantity = model.Quantity
            };
        }
        public static List<IngredientModelDto> ToDtoList(List<IngredientModel> ingredients)
        {
            if (ingredients == null) return null;
            return ingredients.ConvertAll<IngredientModelDto>((input) => { return input; });
        }
        public static List<IngredientModel> ToModelList(List<IngredientModelDto> ingredients)
        {
            if (ingredients == null) return null;
            return ingredients.ConvertAll<IngredientModel>((input) => { return input; });
        }
    }
}