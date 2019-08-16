using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Update
{
    public interface IUpdateMenuItemCommand
    {
        void Execute(UpdateMenuItemModel model);
    }
    public class UpdateMenuItemCommand
    {
    }
}
