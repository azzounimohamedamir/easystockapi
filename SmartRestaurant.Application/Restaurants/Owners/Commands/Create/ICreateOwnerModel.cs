using SmartRestaurant.Application.Commun.Address;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Create
{
    public interface ICreateOwnerModel
    {
        AddressModel Address { get; set; }
        string Alias { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        DateTime DateOfBirth { get; set; }
        string Description { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserId { get; set; }
        string UserName { get; set; }
    }
}