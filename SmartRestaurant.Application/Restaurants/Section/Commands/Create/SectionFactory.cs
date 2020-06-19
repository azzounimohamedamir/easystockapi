using SmartRestaurant.Application.Restaurants.Section.Commands.Models;
using System;

namespace SmartRestaurant.Application.Restaurants.Section.Commands.Create
{
    public static class SectionFactory
    {
        public static Domain.Restaurants.Section ToEntity(this SectionModel model)
        {
            return new Domain.Restaurants.Section
            {
                Alias = model.Alias,
                Description = model.Description,
                CreatedDate = DateTime.Now,
                ImageUri = model.ImageUri,
                RestaurantId = Guid.Parse(model.RestaurantId),
                MenuId = Guid.Parse(model.MenuId),
                Name = model.Name
            };
        }
    }
}
