using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Commands
{
    public class DeleteFactureProformatCommand : DeleteCommand
    {
    }

    public class DeleteFactureProformatCommandValidator : AbstractValidator<DeleteFactureProformatCommand>
    {
        public DeleteFactureProformatCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}