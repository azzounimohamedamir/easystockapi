using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Hotels.Commands
{
    public class DeleteHotelCommand : DeleteCommand
    {
    }

    public class DeleteHotelCommandValidator : AbstractValidator<DeleteHotelCommand>
    {
        public DeleteHotelCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}