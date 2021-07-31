using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
    }

    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(m => m.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}