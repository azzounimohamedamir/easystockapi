using System;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class MenuDto
    {
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public MenuState MenuState { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}
