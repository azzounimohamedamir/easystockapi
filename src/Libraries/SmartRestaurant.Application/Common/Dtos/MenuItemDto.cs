using SmartRestaurant.Application.Common.Enums;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class MenuItemDto
    {
        public Guid MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public MenuItemType Type { get; set; }

    }
}
