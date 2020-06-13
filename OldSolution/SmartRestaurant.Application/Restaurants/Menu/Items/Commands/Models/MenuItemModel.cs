using SmartRestaurant.Application.Services.Models;
using System.Collections.Generic;


namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models
{

    public class MenuItemModel : IMenuItemModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }

        public List<string> Dishes { get; set; }
        public List<string> Products { get; set; }

        public bool IsPackage { get; set; }

        public string GalleryId { get; set; }

        public PriceModel Discount { get; set; }
    }
}
