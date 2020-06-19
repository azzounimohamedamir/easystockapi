using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Dishes.DishAccompaniments.Models
{
    public class DishAccompanyingModel : IDishAccompanyingModel
    {
        public string ParentId { get; set; }
        public string AccompanyingId { get; set; }
        public bool IsDisabled { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
