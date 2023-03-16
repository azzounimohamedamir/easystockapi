using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.OrderDestination.Queries
{
    public class GetAllOrderDestinationListByHotelId : IPagedListQuery<OrderDestinationDto>
    {
        public string HotelId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}