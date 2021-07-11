using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class DeleteSectionCommand : SmartRestaurantCommand
    {
    }

    public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
    {
        public DeleteSectionCommandValidator()
        {
            RuleFor(v => v.CmdId).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}