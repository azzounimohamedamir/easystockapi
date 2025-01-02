using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Commands
{
    public class DeleteBCCommand : DeleteCommand
    {
    }

    public class DeleteBCCommandValidator : AbstractValidator<DeleteBCCommand>
    {
        public DeleteBCCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}