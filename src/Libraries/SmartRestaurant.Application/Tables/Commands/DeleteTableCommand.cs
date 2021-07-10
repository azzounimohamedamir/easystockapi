using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class DeleteTableCommand : SmartRestaurantCommand
    {
    }

    public class DeleteTableCommandValidator : AbstractValidator<DeleteTableCommand>
    {
        public DeleteTableCommandValidator()
        {
            RuleFor(v => v.CmdId).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}