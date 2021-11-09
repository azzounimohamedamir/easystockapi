using System;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderDishSupplement
    {
        public Guid OrderDishSupplementId { get; set; }
        public string SupplementId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
        public Guid OrderDishId { get; set; }
    }
}
