using SmartRestaurant.Application.Restaurants.Places.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Update
{
    public interface IUpdatePlaceModel : ICreatePlaceModel
    {
        string Id { get; set; }
    }
}