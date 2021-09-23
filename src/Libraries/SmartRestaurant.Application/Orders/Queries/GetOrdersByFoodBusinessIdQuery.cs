using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Orders.Queries.Responses;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class GetOrdersByFoodBusinessIdQuery : IRequest<PagedListDto<OrderResponse>>
    {
        public Guid FoodBusinessId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}