using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update
{
    public interface IUpdateRestaurantTypeModel : ICreateRestaurantTypeModel
    {
        string Id { get; set; }
    }
}