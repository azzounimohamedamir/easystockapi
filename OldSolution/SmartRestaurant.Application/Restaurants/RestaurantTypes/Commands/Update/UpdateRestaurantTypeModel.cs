using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update
{
    public class UpdateRestaurantTypeModel : CreateRestaurantTypeModel, IUpdateRestaurantTypeModel
    {
        public string Id { get; set; }

    }
}