using SmartRestaurant.Application.Commun.Address;
using System;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Create
{
    public interface ICreateStaffModel
    {
        AddressModel Address { get; set; }
        string Alias { get; set; }
        DateTime DateOfBirth { get; set; }
        string Description { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string RestaurantId { get; set; }
        string UserId { get; set; }
        string UserName { get; set; }
    }
}