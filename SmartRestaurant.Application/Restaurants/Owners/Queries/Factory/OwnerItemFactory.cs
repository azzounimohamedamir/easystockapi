using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Owners.Queries.Factory
{
    public static class OwnerItemFactory
    {

        public static OwnerItemModel ToOwnerItemModel(this Owner entity)
        {
            if (entity == null) return null;
            return new OwnerItemModel
            {
                Address = entity.Address.ToModel(),
                Alias = entity.Alias,
                DateOfBirth = entity.DateOfBirth,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Id = entity.Id.ToString(),
                UserName = entity.UserName
            };
        }
        public static IEnumerable<OwnerItemModel> ToOwnerItemModels(this IEnumerable<Owner> entities)
        {
            if (entities == null) return null;
            return entities.Select(x => x.ToOwnerItemModel());
        }
    }
}
