using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Common
{
    public class MenuItem : AuditableEntity
    {
        public string Name { get; set; }
        public Names Names { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public float Price { get; set; }
        public int? Quantity { get; set; }=0;
        public bool IsQuantityChecked { get; set; } 
        public float EnergeticValue { get; set; }
        public Guid? FoodBusinessId { get; set; }

        public FoodBusiness FoodBusiness { get; set; }
    }
}
