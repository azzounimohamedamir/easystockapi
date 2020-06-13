using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Foods.Models
{
    public class NutritionModel : INutritionModel
    {
        public NutritionModel()
        {
            Quantity = new QuantityModel();
        }
        public QuantityModel Quantity { get; set; }
        public decimal GlycemicIndex { get; set; }
        public decimal Fibre { get; set; }
        public decimal Calorie { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Lipid { get; set; }
    }
}