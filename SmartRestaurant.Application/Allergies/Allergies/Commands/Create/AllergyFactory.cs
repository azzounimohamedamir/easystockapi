using Helpers;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Update;
using SmartRestaurant.Domain.Allergies;
using System;

namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Create
{

    public static class AllergyFactory
    {
        public static Allergy ToEntity(this CreateAllergyModel model)
        {
            return new Allergy
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Name = model.Name,
                IsDisabled = model.IsDisabled,
                Description = model.Description
            };
        }
        public static void ToEntity(this UpdateAllergyModel model
            , ref Allergy Allergy)
        {

            Allergy.Id = model.Id.ToGuid();
            Allergy.Alias = model.Alias;
            Allergy.Name = model.Name;
            Allergy.IsDisabled = model.IsDisabled;
            Allergy.Description = model.Description;
        }
    }
}
