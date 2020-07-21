using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Restaurants.Queries
{
    public class GetRestaurantsListQuery : IRequest<List<RestaurantDto>>
    {
    }
}
