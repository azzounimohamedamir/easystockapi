using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Reservations.Commands
{
    public class DeleteReservationCommand : SmartRestaurantCommand
    {
    }

    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(m => m.CmdId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}