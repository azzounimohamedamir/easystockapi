using Helpers;
using SmartRestaurant.Application.Services.Commnads.Update;
using SmartRestaurant.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Services.Commnads.Create
{
    public static class ServiceFactory
    {
        public static Service ToEntity(this CreateServiceModel model)
        {
            return new Service
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Description = model.Description,
                Name = model.Name,
                IsDisabled = model.IsDisabled,
                RestaurantId = model.RestaurantId.ToGuid(),

            };
        }

        public static void ToEntity(this UpdateServiceModel model
            , ref Service Service)
        {

            Service.Id = model.Id.ToGuid();
            Service.Alias = model.Alias;
            Service.Description = model.Description;
            Service.Name = model.Name;
            Service.IsDisabled = model.IsDisabled;
            Service.RestaurantId = model.RestaurantId.ToGuid();

        }

     }
}
