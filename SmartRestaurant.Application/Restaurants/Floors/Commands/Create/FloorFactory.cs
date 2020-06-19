using Helpers;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Update;
using SmartRestaurant.Domain.Restaurants;
using System;

namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Create
{
    public static class FloorFactory
    {
        public static Floor ToEntity(this CreateFloorModel model)
        {
            return new Floor
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Name = model.Name,
                Description = model.Description,
                IsDisabled = model.IsDisabled,
                RestaurantId = model.RestaurantId.ToGuid()
            };
        }
        public static void ToEntity(this UpdateFloorModel model
            , ref Floor floor)
        {

            floor.Id = model.Id.ToGuid();
            floor.Alias = model.Alias;
            floor.Name = model.Name;
            floor.IsDisabled = model.IsDisabled;
            floor.Description = model.Description;
            floor.RestaurantId = model.RestaurantId.ToGuid();
        }
    }
}
