using SmartRestaurant.Application.Commun.Address;
using System;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create
{
    public interface ICreateRestaurantModel
    {
        AddressModel AddressModel { get; set; }
        string Alias { get; set; }
        string ChainId { get; set; }
        DateTime CreatedDate { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string OwnerId { get; set; }
        string RestaurantTypeId { get; set; }
    }
}