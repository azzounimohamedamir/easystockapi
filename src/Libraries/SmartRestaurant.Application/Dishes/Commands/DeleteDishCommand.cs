using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class DeleteDishCommand : DeleteCommand
    {
    }

    public class DeleteDishCommandValidator : AbstractValidator<DeleteDishCommand>
    {
        public DeleteDishCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}