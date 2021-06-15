using System;
using FluentValidation;
using MediatR;

namespace SmartRestaurant.Application.Zones.Commands
{
    public class DeleteZoneCommand : IRequest
    {
        public Guid ZoneId { get; set; }
    }

    public class DeleteZoneCommandValidator : AbstractValidator<DeleteZoneCommand>
    {
        public DeleteZoneCommandValidator()
        {
            RuleFor(v => v.ZoneId).Must(val => val != Guid.Empty);
        }
    }
}