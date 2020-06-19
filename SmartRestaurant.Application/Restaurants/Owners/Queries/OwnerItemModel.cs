using SmartRestaurant.Application.Commun.Address;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using System;

namespace SmartRestaurant.Application.Restaurants.Owners.Queries
{
    public class OwnerItemModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string IsDisabled { get; set; }

        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Alias { get; set; }
        public string Description { get; set; }
        public AddressModel Address { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}