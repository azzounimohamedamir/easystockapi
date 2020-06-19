using SmartRestaurant.Application.Commun.Address;
using SmartRestaurant.Domain.Enumerations;
using System;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries
{
    public class StaffItemModel
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Alias { get; set; }
        public string IsDisabled { get; set; }

        public AddressModel Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserId { get; set; }
        public EnumPersoneType Role { get; set; }
    }
}
