using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Models
{
    public interface IDishEquivalenceModel
    {
        string EquivalenceId { get; set; }
        string ParentId { get; set; }
        QuantityModel Quantity { get; set; }
    }
}