using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Models
{
    public interface IDishModel
    {       
        string Alias { get; set; }
        bool CanBeAccompanying { get; set; }
        string Description { get; set; }
        string FamillyId { get; set; }
        string GalleryId { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        TimeSpan PreparationTime { get; set; }
        string RestaurantId { get; set; }
        TimeSpan ServiceTime { get; set; }
        EnumDishType Type { get; set; }
    }
}
