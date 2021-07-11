using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Reservations.Commands
{
    public class CreateReservationCommand : SmartRestaurantCommand
    {
        public CreateReservationCommand()
        {
            CreatedAt = DateTime.Now;
        }

        public string ReservationName { get; set; }
        public int NumberOfDiners { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid FoodBusinessId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; }
    }

    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(reservation => reservation.ReservationName).NotEmpty().MaximumLength(200).MinimumLength(5);
            RuleFor(reservation => reservation.NumberOfDiners).GreaterThan(0).LessThan(1000);
            RuleFor(reservation => reservation.ReservationDate).GreaterThan(date => DateTime.Now);
            RuleFor(reservation => reservation.FoodBusinessId).NotEmpty();
            RuleFor(reservation => reservation.CreatedBy).NotEmpty();
        }
    }
}