using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Restaurants.Places.Commands.Update;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Create
{
    public static class PlaceFactory
    {
        public static Place ToEntity(this CreatePlaceModel model)
        {
            return new Place
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Name = model.Name,
                Description = model.Description,
                IsDisabled = model.IsDisabled,
                TableId = model.TableId.ToGuid(),
            };
        }
        public static void ToEntity(this UpdatePlaceModel model, ref Place Place)
        {

            Place.Id = model.Id.ToGuid();
            Place.Alias = model.Alias;
            Place.Name = model.Name;
            Place.Description = model.Description;
            Place.IsDisabled = model.IsDisabled;
            Place.TableId = model.TableId.ToGuid();
        }
    }
}
