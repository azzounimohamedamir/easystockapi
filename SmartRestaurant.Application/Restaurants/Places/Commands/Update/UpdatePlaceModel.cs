using SmartRestaurant.Application.Restaurants.Places.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Update
{
    public class UpdatePlaceModel : CreatePlaceModel, IUpdatePlaceModel
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public string FloorId { get; set; }
        public string AreaId { get; set; }
        public string WaiterId { get; set; }
        public string TableName { get; set; }
    }
}