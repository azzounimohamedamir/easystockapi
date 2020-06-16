using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid RestaurantId { get; set; }
    }
}
