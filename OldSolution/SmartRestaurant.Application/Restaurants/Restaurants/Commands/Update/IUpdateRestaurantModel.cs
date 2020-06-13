using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update
{
    public interface IUpdateRestaurantModel: ICreateRestaurantModel
    {
        string Id { get; set; }
    }
}