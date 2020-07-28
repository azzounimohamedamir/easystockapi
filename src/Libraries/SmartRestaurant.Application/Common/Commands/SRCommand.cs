using System;
using FluentValidation.Results;
using MediatR;

namespace SmartRestaurant.Application.Common.Commands
{
    public class SRCommand : IRequest<ValidationResult>
    {
        public SRCommand()
        {
            CmdId = Guid.NewGuid();
        }
        public Guid CmdId { get; set; }

    }
}
