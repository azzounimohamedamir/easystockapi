using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Delete
{
    public interface IDeleteMenuCommand
    {
        void Execute(DeleteMenuModel model);
    }
    public class DeleteMenuCommand
    {
    }
}
