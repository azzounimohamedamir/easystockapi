using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Dishes.DishAccompaniments.Models
{
    public interface IDishAccompanyingModel
    {
        string AccompanyingId { get; set; }
        string ParentId { get; set; }
        QuantityModel Quantity { get; set; }
    }
}