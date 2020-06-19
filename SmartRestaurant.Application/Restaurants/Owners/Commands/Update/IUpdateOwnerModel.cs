using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Update
{
    public interface IUpdateOwnerModel: ICreateOwnerModel
    {
        string Id { get; set; }
    }
}