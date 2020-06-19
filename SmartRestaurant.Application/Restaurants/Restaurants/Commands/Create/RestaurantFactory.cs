using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using SmartRestaurant.Application.Commun.Address;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create
{
    public static class RestaurantFactory
    {
        public static Restaurant ToEntity(this CreateRestaurantModel model)
        {
            return new Restaurant
            {
                Id = Guid.NewGuid(),
                Address = model.AddressModel.ToValueObject(),
                Alias = model.Alias,
                ChainId = model.ChainId.ToNullableGuid(),
                OwnerId = model.OwnerId.ToGuid(),
                RestaurantTypeId = model.RestaurantTypeId.ToGuid(),
                CreatedDate = DateTime.Now,
                Description = model.Description,
                IsDisabled = model.IsDisabled,
                Name = model.Name,
            };
        }
        public static void ToEntity(this UpdateRestaurantModel model
            , ref Restaurant restaurant)
        {

            restaurant.Id = model.Id.ToGuid();
            restaurant.Address = model.AddressModel.ToValueObject();
            restaurant.Alias = model.Alias;
            restaurant.ChainId = model.ChainId.ToNullableGuid();
            restaurant.RestaurantTypeId = model.RestaurantTypeId.ToGuid();
            restaurant.CreatedDate = DateTime.Now;
            restaurant.Description = model.Description;
            restaurant.IsDisabled = model.IsDisabled;
            restaurant.Name = model.Name;
            restaurant.OwnerId = model.OwnerId.ToGuid();
        }
        public static Address ToValueObject(this AddressModel model)
        {
            if (model == null)
                return new Address("", "", "", "", "");
            return new Address(model.Street, model.City,
                model.Street, model.Country, model.ZipCode);
        }

        public static AddressModel ToModel(this Address model)
        {
            if (model == null) return null;
            return new AddressModel
            {
                City = model.City,
                Country = model.Country,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                State = model.State,
                Street = model.Street,
                ZipCode = model.ZipCode
            };
        }
    }
}

