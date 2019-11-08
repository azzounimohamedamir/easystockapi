using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.FoodCompositions.Queries.GetAll
{
    public class FoodCompositionModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SlugUrl { get; set; }    
        public QuantityModel Quantity { get; set; }
    }
}