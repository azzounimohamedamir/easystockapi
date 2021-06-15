using System;
using FluentValidation.Results;
using MediatR;

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