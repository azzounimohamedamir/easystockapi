using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Menus.Commands
{
    public class DeleteMenuCommand : SmartRestaurantCommand
    {
    }

    public class DeleteMenuCommandValidator : AbstractValidator<DeleteMenuCommand>
    {
        public DeleteMenuCommandValidator()
        {
            RuleFor(v => v.CmdId).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}