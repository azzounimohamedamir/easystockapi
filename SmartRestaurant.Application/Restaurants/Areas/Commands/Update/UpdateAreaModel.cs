using SmartRestaurant.Application.Restaurants.Areas.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Update
{
    public class UpdateAreaModel : CreateAreaModel, IUpdateAreaModel
    {
        public string Id { get; set; }
        public string FloorName { get; set; }
        public string RestaurantId { get; set; }
    }
}