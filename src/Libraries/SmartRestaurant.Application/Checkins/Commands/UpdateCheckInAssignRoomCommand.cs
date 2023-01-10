using System;
using System.Runtime.InteropServices;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;

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
            RuleFor(c => c.Email)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .MaximumLength(200)
              .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");
            RuleFor(c => c.HotelId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID");


        }
    }
}