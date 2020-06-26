using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.Restaurants.Queries
{
    public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
    {
        public Guid RestaurantId { get; set; }
    }
}