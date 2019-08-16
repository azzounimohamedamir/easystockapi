using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Update
{
    public interface IUpdateMenuCommand
    {
        void Execute(UpdateMenuModel model);
    }
    public class UpdateMenuCommand
    {
    }
}
