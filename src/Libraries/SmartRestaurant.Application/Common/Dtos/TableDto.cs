using System;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class TableDto
    {
        public Guid TableId { get; set; }
        public int TableNumber { get; set; }
        public Guid ZoneId { get; set; }
        public int Capacity { get; set; }
        public TableState TableState { get; set; }
        public NamesDto ZoneNames { get; set; }
        public Guid FoodBuisnessId { get; set; }
        public string FoodBuisnesName { get; set; }
    }
}