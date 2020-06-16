using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid RestaurantId { get; set; }
    }
}
