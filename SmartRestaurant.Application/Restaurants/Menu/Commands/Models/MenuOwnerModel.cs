using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Models
{
    public class MenuOwnerModel: IMenuOwnerModel
    {
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public string Name { get; set; }
    }

    public interface IMenuOwnerModel
    {
        string Description { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
    }
}
