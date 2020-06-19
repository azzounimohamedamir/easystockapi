using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries.Factory
{
    public static class StaffItemFactory
    {
        public static List<StaffItemModel> ToStaffItemModels(this IEnumerable<Staff> entities)
        {
            return entities.Select(x => x.ToStaffItemModel()).ToList();
        }

        public static StaffItemModel ToStaffItemModel(this Staff entitie)
        {
            return new StaffItemModel
            {
                Address = entitie.Address?.ToModel(),
                Alias = entitie.Alias,
                DateOfBirth = entitie.DateOfBirth,
                FirstName = entitie.FirstName,
                LastName = entitie.LastName,
                Id = entitie.Id.ToString(),
                IsDisabled = entitie.IsDisabled.DisabledDisplay(),
                RestaurantName = entitie.Restaurant.Name,
                RestaurantId = entitie.RestaurantId.ToString(),
                UserId = entitie.UserId,
                Role = entitie.StaffRole
            };
        }
    }
}
