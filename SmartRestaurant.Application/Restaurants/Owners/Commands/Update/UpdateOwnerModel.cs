using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Update
{
    public class UpdateOwnerModel : CreateOwnerModel, IUpdateOwnerModel
    {
        public string Id { get; set; }
    }
}