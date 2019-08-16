using SmartRestaurant.Application.Services.Models;

namespace SmartRestaurant.Forms.Models
{
    public class DishNutrritionModelDto : BaseModel
    {
        public decimal GlycemicIndex { get; set; }
        public decimal Fibre { get; set; }
        public decimal Calorie { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Lipid { get; set; }

        public static implicit operator DishNutrritionModelDto(DishNutrritionModel model)
        {
            if (model == null) return null;
            return new DishNutrritionModelDto
            {
                GlycemicIndex = model.GlycemicIndex,
                Fibre = model.Fibre,
                Calorie = model.Calorie,
                Protein = model.Protein,
                Carbohydrate = model.Carbohydrate,
                Lipid = model.Lipid
            };
        }
    }
}