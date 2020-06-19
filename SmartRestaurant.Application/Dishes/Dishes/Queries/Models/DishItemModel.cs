using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Resources.Enumerations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Dishes.Dishes.Queries.Models
{
    public class DishItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string RestaurantName { get; set; }
        public string Type { get; set; }
        public string IsDisabled { get; set; }
        public string PictureUrl { get; set; }

        public static Expression<Func<Dish, DishItemModel>> Projection
        {
            get
            {
                return x => new DishItemModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    FamilyName = x.Family.Name,
                    RestaurantName = x.Restaurant.Name,
                    Type = x.Type.EnumValueToText(nameof(EnumDishTypeResource)),
                    IsDisabled = x.IsDisabled.ToText(),
                    PictureUrl = x.Gallery.Pictures.FirstOrDefault().ImageUrl,
                };
            }
        }
    }
}


