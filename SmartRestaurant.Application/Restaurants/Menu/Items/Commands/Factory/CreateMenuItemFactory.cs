using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;
using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Factory
{
    public interface ICreateMenuItemFactory
    {
        MenuItem Create(MenuItemModel model);
    }
    public class CreateMenuItemFactory : ICreateMenuItemFactory
    {       

        public MenuItem Create(MenuItemModel model)
        {
            return new MenuItem
            {
                Alias=model.Alias,
                Name=model.Name,
                Description=model.Description,
                IsDisabled=model.IsDisabled,
                IsPackage=model.IsPackage,

            };
        }
    }
}
