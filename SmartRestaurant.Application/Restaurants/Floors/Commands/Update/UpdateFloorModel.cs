using SmartRestaurant.Application.Restaurants.Floors.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Update
{
    public class UpdateFloorModel : CreateFloorModel, IUpdateFloorModel
    {
        public string Id { get; set; }
        public string RestaurantName { get; set; }
    }
}