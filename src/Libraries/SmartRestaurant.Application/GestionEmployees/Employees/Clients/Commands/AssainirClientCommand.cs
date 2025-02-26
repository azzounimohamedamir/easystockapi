using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands
{
    public class AssainirClientCommand : UpdateCommand
    {

    }

    public class AssainirClientCommandValidator : AbstractValidator<AssainirClientCommand>
    {
        public AssainirClientCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}