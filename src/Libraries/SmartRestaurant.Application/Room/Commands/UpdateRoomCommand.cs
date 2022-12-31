using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Rooms.Commands
{
    public class UpdateRoomCommand : UpdateCommand
    {
        public Guid Id { get; set; }

        public Guid BuildingId { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int NumberOfBeds { get; set; }
        public string ClientEmail { get; set; }
        public bool isBooked { get; set; }
    }

    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(room => room.BuildingId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID"); ;
            RuleFor(x => x.ClientEmail).NotEmpty().Must(ValidatorHelper.ValidateEmail)
                .WithMessage("'Email' is invalide");
        }

    }
}