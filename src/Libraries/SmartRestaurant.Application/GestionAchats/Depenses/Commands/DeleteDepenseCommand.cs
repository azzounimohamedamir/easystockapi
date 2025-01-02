using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Depenses.Commands
{
    public class DeleteDepenseCommand : DeleteCommand
    {
    }

    public class DeleteDepenseCommandValidator : AbstractValidator<DeleteDepenseCommand>
    {
        public DeleteDepenseCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}