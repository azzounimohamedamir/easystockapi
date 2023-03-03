using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.TypeReclamation.Commands
{
    public class DeleteTypeReclamationCommand : DeleteCommand
    {
    }

    public class DeleteSectionCommandValidator : AbstractValidator<DeleteTypeReclamationCommand>
    {
        public DeleteSectionCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}