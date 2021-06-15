using System;
using MediatR;

namespace SmartRestaurant.Application.Menus.Commands
{
    public class DeleteMenuCommand : IRequest
    {
        public Guid MenuId { get; set; }
    }
}