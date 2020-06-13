using SmartRestaurant.Application.Commun.Address;
using System;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create
{
    public class CreateRestaurantModel : ICreateRestaurantModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string ChainId { get; set; }
        public string OwnerId { get; set; }
        public string RestaurantTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public AddressModel AddressModel { get; set; }
        public bool IsDisabled { get; set; }
    }
}