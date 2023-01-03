using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Buildings.Commands
{
    public class DeleteBuildingCommand:DeleteCommand
    {

    }
    public class DeleteBuildingCommandValidator : AbstractValidator<DeleteBuildingCommand>
    {
        public DeleteBuildingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
