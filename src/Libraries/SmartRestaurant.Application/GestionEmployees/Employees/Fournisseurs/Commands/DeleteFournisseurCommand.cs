using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Commands
{
    public class DeleteFournisseurCommand : DeleteCommand
    {
    }

    public class DeleteFournisseurCommandValidator : AbstractValidator<DeleteFournisseurCommand>
    {
        public DeleteFournisseurCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}