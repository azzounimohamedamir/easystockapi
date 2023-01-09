using System;
using System.Runtime.InteropServices;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Checkins.Commands
{
    public class UpdateCheckInAssignRoomCommand : UpdateCommand
    {
        public string? ClientId { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActivate { get; set; }
        public Guid HotelId { get; set; }
        public Guid? RoomId { get; set; }
        public int? RoomNumber { get; set; }
        public int? LengthOfStay { get; set; }
        public DateTime ? Startdate { get; set; }

    }

    public class UpdateCheckInAssignRoomCommandValidator : AbstractValidator<UpdateCheckInAssignRoomCommand>
    {
        UpdateCheckInAssignRoomCommandValidator()
        {
            RuleFor(c => c.Id)
                 .NotEmpty();
        }
    }
}