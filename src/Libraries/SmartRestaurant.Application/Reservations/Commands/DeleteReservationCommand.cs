using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Reservations.Commands
{
    public class DeleteReservationCommand : DeleteCommand
    {
    }

    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(m => m.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}