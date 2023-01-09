using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Rooms.Commands
{
    public class DeleteRoomCommand : DeleteCommand
    {
    }

    public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull();
        }
    }
}