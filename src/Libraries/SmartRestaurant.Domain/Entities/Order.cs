using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDateTime = DateTime.Now;
        }

        public Guid OrderId { get; set; }
        public List<OrderDish> OrderDishes { get; set; }
        public float TotalToPay { get; set; }
        public float MoneyReceived { get; set; }
        public float MoneyReturned { get; set; }
        public OrderTypes OrderType { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}