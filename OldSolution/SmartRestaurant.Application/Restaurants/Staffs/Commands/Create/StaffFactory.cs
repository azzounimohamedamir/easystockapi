using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Update;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Create
{
    public static class StaffFactory
    {
        public static Staff ToEntity(this CreateStaffModel model)
        {
            return new Staff
            {
                Id = Guid.NewGuid(),
                Address = model.Address.ToValueObject(),
                Alias = model.Alias,
                
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsDisabled = model.IsDisabled,
                UserName = model.FirstName ,
                StaffRole = model.StaffRole,
                RestaurantId = model.RestaurantId.ToGuid(),
                UserId = model.UserId
            };
        }
        public static void ToEntity(this UpdateStaffModel model,
            ref Staff staff)
        {

            staff.Id = model.Id.ToGuid();
            staff.Address = model.Address.ToValueObject();
            staff.Alias = model.Alias;
            staff.DateOfBirth = model.DateOfBirth;
            staff.FirstName = model.FirstName;
            staff.LastName = model.LastName;
            staff.IsDisabled = model.IsDisabled;
            staff.RestaurantId = model.RestaurantId.ToGuid();
            staff.UserId = model.UserId;
        }
    }
}
