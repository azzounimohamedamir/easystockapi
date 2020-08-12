using MediatR;
using System;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class DeleteTableCommand : IRequest
    {
        public Guid TableId { get; set; }

    }
}
