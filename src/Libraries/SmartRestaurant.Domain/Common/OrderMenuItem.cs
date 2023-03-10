using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Common
{
    public class OrderMenuItem
    {
        public string Name { get; set; }
        public Names Names { get; set; }
        public float InitialPrice { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }      
        public float EnergeticValue { get; set; }
        public string Description { get; set; }
        public string TableId { get; set; }
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public float Quantity { get; set; }
        public Guid OrderId { get; set; }
        public long OdooId { get; set; }
    }
}
