using SmartRestaurant.Application.Restaurants.Chains.Commands.Update;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Restaurants.Chains.Commands.Create
{
    public static class ChainFactory
    {
        public static Chain ToEntity(this CreateChainModel model)
        {
            return new Chain
            {
                Id = Guid.NewGuid(),
                
                Alias = model.Alias,
                Name = model.Name,
                Description = model.Description,
                IsDisabled = model.IsDisabled,
                OwnerId = model.OwnerId.ToGuid()
            };
        }
        public static void ToEntity(this UpdateChainModel model, ref Chain Chain)
        {
            Chain.Id = model.Id.ToGuid();
            Chain.Alias = model.Alias;
            Chain.Name = model.Name;
            Chain.IsDisabled = model.IsDisabled;
            Chain.OwnerId = model.OwnerId.ToGuid();
        }
    }
}
