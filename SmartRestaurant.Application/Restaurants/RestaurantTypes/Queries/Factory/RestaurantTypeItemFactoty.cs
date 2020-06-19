using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.Factory
{
    
   public static class RestaurantTypeItemFactory
    {
        public static List<RestaurantTypeItemModel> ToRestaurantTypeItemModels(this IEnumerable<RestaurantType> entities)
        {
            return entities.Select(x => x.ToRestaurantTypeItemModel()).ToList();
        }

        public static RestaurantTypeItemModel ToRestaurantTypeItemModel(this RestaurantType entitie)
        {
            return new RestaurantTypeItemModel
            {
               Alias = entitie.Alias,
               Description = entitie.Description,
               Id = entitie.Id.ToString(),
                IsDisabled = entitie.IsDisabled.DisabledDisplay(),
                Name = entitie.Name
            };
        }
    }
}
