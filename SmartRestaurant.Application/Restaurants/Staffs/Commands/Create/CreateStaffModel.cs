using System;
using SmartRestaurant.Application.Commun.Address;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Create
{
    public class CreateStaffModel : ICreateStaffModel
    {
        public string RestaurantId { get; set; }
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
        public EnumPersoneType StaffRole { get; set; }
    }
}