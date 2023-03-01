using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class OrderNotificationDto
    {
        public string OrderId { get; set; }
        public OrderNotificationType Type { get; set; }
        public Array Read { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FoodBusinessId { get; set; }

    }
}
