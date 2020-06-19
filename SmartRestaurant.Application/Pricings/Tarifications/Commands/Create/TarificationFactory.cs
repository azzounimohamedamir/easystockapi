using Helpers;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Update;
using SmartRestaurant.Domain.Pricings;
using System;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Create
{
    public static class TarificationFactory
    {
        public static Tarification ToEntity(this CreateTarificationModel model)
        {
            return new Tarification
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Name = model.Name,
                IsDisabled = model.IsDisabled,
                Description = model.Description,
                IsPercentage = model.IsPercentage,
                Amount = model.Amount,
                RestaurantId = model.RestaurantId.ToGuid()
            };
        }
        public static void ToEntity(this UpdateTarificationModel model
            , ref Tarification Tarification)
        {

            Tarification.Id = model.Id.ToGuid();
            Tarification.Alias = model.Alias;
            Tarification.Name = model.Name;
            Tarification.IsPercentage = model.IsPercentage;
            Tarification.Amount = model.Amount;
            Tarification.IsDisabled = model.IsDisabled;
            Tarification.Description = model.Description;
            Tarification.RestaurantId = model.RestaurantId.ToGuid();
        }
    }
}
