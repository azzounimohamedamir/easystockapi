using SmartRestaurant.Application.Restaurants.Floors.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Update
{
    public interface IUpdateFloorModel : ICreateFloorModel
    {
        string Id { get; set; }
    }
}