using System;

namespace SmartRestaurant.Application.Restaurants.Chains.Commands.Create
{
    public interface ICreateChainModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        string OwnerId { get; set; }
    }
}