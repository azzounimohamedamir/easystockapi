using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class Table : AuditableEntity
    {
        public Guid TableId { get; set; }
        public int TableNumber { get; set; }
        public Guid ZoneId { get; set; }
        public Zone Zone { get; set; }
        public int Capacity { get; set; }
        public TableState TableState { get; set; }

    }
}
