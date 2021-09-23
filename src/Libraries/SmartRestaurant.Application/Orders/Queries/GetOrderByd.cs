using System;
using MediatR;
using SmartRestaurant.Application.Orders.Queries.Responses;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class GetOrderByd : IRequest<OrderResponse>
    {
        public Guid OrderId { get; set; }
    }
}