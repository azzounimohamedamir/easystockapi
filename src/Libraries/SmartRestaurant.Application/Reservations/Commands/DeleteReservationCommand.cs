using FluentValidation;
using MediatR;
using System;

namespace SmartRestaurant.Application.Reservations.Commands
{
    public class DeleteReservationCommand :IRequest
    {
        public Guid ReservationId { get; set; }
    }

    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(v => v.ReservationId)
               .NotEmpty();
        }
    }
}
