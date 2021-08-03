using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class DeleteTableCommand : DeleteCommand
    {
    }

    public class DeleteTableCommandValidator : AbstractValidator<DeleteTableCommand>
    {
        public DeleteTableCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}