using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using System;

namespace SmartRestaurant.Application.Common.Commands
{
    public class DeleteCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
    }
}