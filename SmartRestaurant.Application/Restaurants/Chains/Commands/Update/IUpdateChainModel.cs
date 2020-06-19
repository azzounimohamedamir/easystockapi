using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Chains.Commands.Update
{
    public interface IUpdateChainModel : ICreateChainModel
    {
        string Id { get; set; }
    }
}