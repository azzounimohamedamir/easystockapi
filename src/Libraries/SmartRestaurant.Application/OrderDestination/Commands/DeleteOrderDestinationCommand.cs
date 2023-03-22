using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.OrderDestination.Commands
{
    public class DeleteOrderDestinationCommand : DeleteCommand
    {
    }

    public class DeleteOrderDestinationCommandValidator : AbstractValidator<DeleteOrderDestinationCommand>
    {
        public DeleteOrderDestinationCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}