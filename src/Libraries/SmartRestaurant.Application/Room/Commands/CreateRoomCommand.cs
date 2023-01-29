using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Rooms.Commands
{
    public class CreateRoomCommand : CreateCommand
    {
        public Guid BuildingId { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int NumberOfBeds { get; set; }
        public string ClientEmail { get; set; }
        public bool IsBooked { get; set; }
        public string? ClientId { get; set; }
    }

    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {

            

            RuleFor(room => room.BuildingId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID"); ;

        }
    }
}