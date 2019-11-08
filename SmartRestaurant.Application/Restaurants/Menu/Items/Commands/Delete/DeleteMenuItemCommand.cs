using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Delete
{
    public interface IDeleteMenuItemCommand
    {
        void Execute(DeleteMenuItemModel model);
    }
    public class DeleteMenuItemCommand
    {
    }
}
