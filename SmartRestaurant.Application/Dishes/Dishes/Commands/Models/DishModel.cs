using SmartRestaurant.Domain.Enumerations;
using System;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Models
{
    public class DishModel : IDishModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public string RestaurantId { get; set; }
        public EnumDishType Type { get; set; }
        public string FamillyId { get; set; }
        public string GalleryId { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public TimeSpan ServiceTime { get; set; }
        public bool CanBeAccompanying { get; set; }

    }
}
