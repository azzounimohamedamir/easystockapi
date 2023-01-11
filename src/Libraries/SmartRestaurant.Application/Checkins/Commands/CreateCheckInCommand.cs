using System;
using System.Runtime.InteropServices;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Checkins.Commands
{
    public class CreateCheckInCommand : CreateCommand
    {
        public string? ClientId { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActivate { get; set; }
        public Guid hotelId { get; set; }
        public Guid? RoomId { get; set; }
        public int? RoomNumber { get; set; }
        public int? LengthOfStay { get; set; }
        public DateTime ? Startdate { get; set; }

    }

    public class CreateCheckInCommandValidator : AbstractValidator<CreateCheckInCommand>
    {
        public CreateCheckInCommandValidator()
        {
         
        }
    }
}