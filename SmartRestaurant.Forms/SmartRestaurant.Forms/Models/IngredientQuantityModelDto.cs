using SmartRestaurant.Application.Services.Models;

namespace SmartRestaurant.Forms.Models
{
    public class IngredientQuantityModelDto : BaseModel
    {
        public string UnitName { get; set; }
        public decimal Value { get; set; }

        public static implicit operator IngredientQuantityModelDto(IngredientQuantityModel model)
        {
            if (model == null) return null;
            return new IngredientQuantityModelDto
            {
                UnitName = model.UnitName,
                Value = model.Value
            };
        }
        public static implicit operator IngredientQuantityModel(IngredientQuantityModelDto model)
        {
            if (model == null) return null;
            return new IngredientQuantityModel
            {
                UnitName = model.UnitName,
                Value = model.Value
            };
        }
    }
}