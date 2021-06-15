using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class Menu : AuditableEntity
    {
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public MenuState MenuState { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
    }
}