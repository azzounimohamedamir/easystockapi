using System;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderOccupiedTable
    {
        public Guid OrderOccupiedTableId { get; set; }
        public string TableId { get; set; }
        public Guid OrderId { get; set; }

    }
}
