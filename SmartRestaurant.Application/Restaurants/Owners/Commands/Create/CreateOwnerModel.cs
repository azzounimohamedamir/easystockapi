using SmartRestaurant.Application.Commun.Address;
using System;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Create
{
    public class CreateOwnerModel : ICreateOwnerModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Alias { get; set; }
        public string Description { get; set; }
        public AddressModel Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserId { get; set; }
        public bool IsDisabled { get; set; }
    }
}