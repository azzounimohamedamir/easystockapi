using System;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Update;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Create
{
    public static class MenuFactory
    {
        public static Domain.Restaurants.Menu ToEntity(this MenuModel model)
        {
            return new Domain.Restaurants.Menu
            {
                Id = (string.IsNullOrEmpty(model.MenuId))? Guid.NewGuid() : Guid.Parse(model.MenuId),
                CreatedDate = DateTime.Now,
                Description = model.Description,
                IsDisabled = model.IsDisabled,
                Name = model.Name,
                RestaurantId = Guid.Parse(model.RestaurantId)
            };
        }
       
    }
}
