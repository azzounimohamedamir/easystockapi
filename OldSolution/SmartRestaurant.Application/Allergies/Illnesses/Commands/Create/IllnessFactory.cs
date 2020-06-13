using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Create
{
    public static class IllnessFactory
    {
        public static Illness ToEntity(this CreateIllnessModel model)
        {
            return new Illness
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Name = model.Name,
                IsDisabled = model.IsDisabled,
                Description = model.Description
            };
        }
        public static void ToEntity(this UpdateIllnessModel model
            , ref Illness Illness)
        {

            Illness.Id = model.Id.ToGuid();
            Illness.Alias = model.Alias;
            Illness.Name = model.Name;
            Illness.IsDisabled = model.IsDisabled;
            Illness.Description = model.Description;
        }
    }
}
