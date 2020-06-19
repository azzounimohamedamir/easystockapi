using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Models
{
    public class DishEquivalenceModel : IDishEquivalenceModel
    {
        public string ParentId { get; set; }
        public string EquivalenceId { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
