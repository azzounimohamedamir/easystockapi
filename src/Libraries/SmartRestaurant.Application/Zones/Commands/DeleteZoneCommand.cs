using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Zones.Commands
{
    public class DeleteZoneCommand : DeleteCommand
    {
    }

    public class DeleteZoneCommandValidator : AbstractValidator<DeleteZoneCommand>
    {
        public DeleteZoneCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}