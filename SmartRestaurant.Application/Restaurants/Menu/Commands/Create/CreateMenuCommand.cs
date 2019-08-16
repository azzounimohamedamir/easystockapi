using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Create
{
    public interface ICreateMenuCommand
    {
        void Execute(CreateMenuModel model);
    }

    public class CreateMenuCommand
    {

    }
}
