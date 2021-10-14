using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodBusinessClient.Commands
{
    public class DeleteFoodBusinessClientCommand : DeleteCommand
    {
    }

    public class DeleteFoodBusinessClientCommandValidator : AbstractValidator<DeleteFoodBusinessClientCommand>
    {
        public DeleteFoodBusinessClientCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}
