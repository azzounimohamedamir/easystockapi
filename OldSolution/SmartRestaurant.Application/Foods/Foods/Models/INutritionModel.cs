using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Foods.Models
{
    public interface INutritionModel
    {
        decimal Calorie { get; set; }
        decimal Carbohydrate { get; set; }
        decimal Fibre { get; set; }
        decimal GlycemicIndex { get; set; }
        decimal Lipid { get; set; }
        decimal Protein { get; set; }

        QuantityModel Quantity { get; set; }
    }
}