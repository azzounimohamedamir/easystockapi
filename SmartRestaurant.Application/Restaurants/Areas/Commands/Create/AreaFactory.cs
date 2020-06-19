using Helpers;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Update;
using SmartRestaurant.Domain.Restaurants;
using System;

namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Create
{
    public static class AreaFactory
    {
        public static Area ToEntity(this CreateAreaModel model)
        {
            return new Area
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Name = model.Name,
                IsDisabled = model.IsDisabled,
                Description = model.Description,
                FloorId = model.FloorId.ToGuid()
            };
        }
        public static void ToEntity(this UpdateAreaModel model
            , ref Area area)
        {

            area.Id = model.Id.ToGuid();
            area.Alias = model.Alias;
            area.Name = model.Name;
            area.IsDisabled = model.IsDisabled;
            area.Description = model.Description;
            area.FloorId = model.FloorId.ToGuid();

        }
    }
}
