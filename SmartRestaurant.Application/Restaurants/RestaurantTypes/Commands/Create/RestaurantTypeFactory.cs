using Helpers;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update;
using SmartRestaurant.Domain.Restaurants;
using System;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create
{
    public static class RestaurantTypeFactory
    {
        public static RestaurantType ToEntity(this CreateRestaurantTypeModel model)
        {
            return new RestaurantType
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Alias = model.Alias,
                IsDisabled = model.IsDisabled,
                Description = model.Description
            };
        }
        public static void ToEntity(this UpdateRestaurantTypeModel model
            , ref RestaurantType restaurantType)
        {
            restaurantType.Id = model.Id.ToGuid();
            restaurantType.Name = model.Name;
            restaurantType.Alias = model.Alias;
            restaurantType.IsDisabled = model.IsDisabled;
            restaurantType.Description = model.Description;
        }
    }
}
