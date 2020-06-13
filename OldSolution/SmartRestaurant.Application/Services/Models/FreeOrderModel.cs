using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Services.Models
{
    public class FreeOrderItemModel
    {
        public EnumWhom Whom { get; set; }
        public OrderItemModel ItemModel { get; set; }
        public string UserId { get; set; }
        public string Causes { get; set; }
    }

    public class FreeOrderModel
    {
        public EnumWhom Whom { get; set; }
        public OrderModel Order { get; set; }
        public string UserId { get; set; }
        public string Causes { get; set; }
    }
}
