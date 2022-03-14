using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class DeleteSubSectionCommand : DeleteCommand
    {
    }

    public class DeleteSubSectionCommandValidator : AbstractValidator<DeleteSubSectionCommand>
    {
        public DeleteSubSectionCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}