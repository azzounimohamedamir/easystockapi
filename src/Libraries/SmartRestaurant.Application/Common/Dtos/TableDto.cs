using SmartRestaurant.Domain.Enums;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class TableDto
    {
        public Guid TableId { get; set; }
        public int TableNumber { get; set; }
        public Guid ZoneId { get; set; }
        public int Capacity { get; set; }
        public TableState TableState { get; set; }
    }
}
