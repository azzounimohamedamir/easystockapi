using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.Reservations.Commands
{
    public class UpdateReservationCommand : IRequest<NoContent>
    {
        public UpdateReservationCommand()
        {
            LastModifiedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string ReservationName { get; set; }
        public int NumberOfDiners { get; set; }
        public DateTime ReservationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; }
    }

    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(reservation => reservation.ReservationName).NotEmpty().MaximumLength(200).MinimumLength(5);
            RuleFor(reservation => reservation.NumberOfDiners).GreaterThan(0).LessThan(1000);
            RuleFor(reservation => reservation.ReservationDate).GreaterThan(date => DateTime.Now);
            RuleFor(reservation => reservation.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}