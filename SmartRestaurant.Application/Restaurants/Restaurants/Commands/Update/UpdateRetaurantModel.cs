using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update
{
    public class UpdateRestaurantModel : CreateRestaurantModel, IUpdateRestaurantModel
    {
        public string Id { get; set; }
        public string AllergyName { get; set; }
        public string ChainName { get; set; }
        public string RestaurantTypeName { get; set; }
    }
}