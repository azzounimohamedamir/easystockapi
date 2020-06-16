using MediatR;
using System;

namespace SmartRestaurant.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
