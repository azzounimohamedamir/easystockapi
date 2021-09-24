using System;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Orders.Queries.Responses
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public List<OrderDishResponse> OrderDishes { get; set; }
        public float TotalToPay { get; set; }
        public float MoneyReceived { get; set; }
        public float MoneyReturned { get; set; }
        public CurrencyDto ExchangeCurrency { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}