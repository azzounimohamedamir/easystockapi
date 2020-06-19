using SmartRestaurant.Application.Services.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models
{
    public interface IMenuItemModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        PriceModel Discount { get; set; }
        List<string> Dishes { get; set; }
        string GalleryId { get; set; }
        bool IsDisabled { get; set; }
        bool IsPackage { get; set; }
        string Name { get; set; }
        List<string> Products { get; set; }
    }
}