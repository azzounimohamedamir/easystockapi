using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Create
{
    public static class OwnerFactory
    {
        public static Owner ToEntity(this CreateOwnerModel model)
        {
            return new Owner
            {
                Id = Guid.NewGuid(),
                Address = model.Address.ToValueObject(),
                Alias = model.Alias,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsDisabled = model.IsDisabled,
                UserId = model.UserId
            };
        }
        public static void ToEntity(this UpdateOwnerModel model,ref Owner Owner)
        {
            Owner.Id = model.Id.ToGuid();
            Owner.Address = model.Address.ToValueObject();
            Owner.Alias = model.Alias;
            Owner.DateOfBirth = model.DateOfBirth;
            Owner.FirstName = model.FirstName;
            Owner.LastName = model.LastName;
            Owner.IsDisabled = model.IsDisabled;
            Owner.UserId = model.UserId;           
        }
    }
}
