using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Foods.Foods.Models
{
    public class FoodCompositionModel
    {
        public string Id { get; set; }
        public bool IsDesabled { get; set; }
        public string Alias { get; set; }
        public string FoodId { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
