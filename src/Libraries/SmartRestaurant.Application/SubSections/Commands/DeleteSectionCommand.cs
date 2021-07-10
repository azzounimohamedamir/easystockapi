using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class DeleteSubSectionCommand : SmartRestaurantCommand
    {
    }

    public class DeleteSubSectionCommandValidator : AbstractValidator<DeleteSubSectionCommand>
    {
        public DeleteSubSectionCommandValidator()
        {
            RuleFor(v => v.CmdId).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}