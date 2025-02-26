using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Commands
{
    public class DeleteCaisseCommand : DeleteCommand
    {
    }

    public class DeleteCaisseCommandValidator : AbstractValidator<DeleteCaisseCommand>
    {
        public DeleteCaisseCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}