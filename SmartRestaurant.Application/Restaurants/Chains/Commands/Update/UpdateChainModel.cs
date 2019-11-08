using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Chains.Commands.Update
{
    public class UpdateChainModel : CreateChainModel, IUpdateChainModel
    {
        public string Id { get; set; }
    }
}