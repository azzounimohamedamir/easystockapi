using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.HotelServices.Commands
{
    public class DeleteHotelServiceCommand : DeleteCommand
    {
    }

    public class DeleteHotelServiceCommandValidator : AbstractValidator<DeleteHotelServiceCommand>
    {
        public DeleteHotelServiceCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
