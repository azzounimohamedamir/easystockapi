using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ZoneWithNumberOfOrdersDto
    {
        public Guid ZoneId { get; set; }
        public Guid TableId { get; set; }
        public TableState TableState { get; set; }
        public int TableNumber { get; set; }
        public string ZoneTitle { get; set; }
        public OrderStatuses OrderStatus { get; set; }
        public int NumberOfOrders { get; set; }

        public Names Names { get; set; }
    }
}
