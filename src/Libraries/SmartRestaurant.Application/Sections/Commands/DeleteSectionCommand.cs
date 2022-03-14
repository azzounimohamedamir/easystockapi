using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class DeleteSectionCommand : DeleteCommand
    {
    }

    public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
    {
        public DeleteSectionCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}