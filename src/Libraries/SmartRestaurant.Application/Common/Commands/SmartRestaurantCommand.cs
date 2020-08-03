using FluentValidation.Results;
using MediatR;
using System;

namespace SmartRestaurant.Application.Common.Commands
{
    public class SmartRestaurantCommand : IRequest<ValidationResult>
    {
        public SmartRestaurantCommand()
        {
            CmdId = Guid.NewGuid();
        }
        public Guid CmdId { get; set; }

    }
}
