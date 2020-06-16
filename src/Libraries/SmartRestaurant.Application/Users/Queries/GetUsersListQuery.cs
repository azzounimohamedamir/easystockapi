using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Users.Queries
{
    public class GetUsersListQuery : IRequest<List<UserDto>>
    {
    }
}
