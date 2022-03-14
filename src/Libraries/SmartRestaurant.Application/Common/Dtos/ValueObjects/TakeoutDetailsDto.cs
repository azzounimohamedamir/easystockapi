using SmartRestaurant.Domain.Enums;
using System;

namespace SmartRestaurant.Application.Common.Dtos.ValueObjects
{
    public class TakeoutDetailsDto
    {
        public DateTime? DeliveryTime { get; set; }
        public TakeoutType Type { get; set; }
    }
}
