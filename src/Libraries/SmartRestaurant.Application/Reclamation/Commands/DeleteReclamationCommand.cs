using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.TypeReclamation.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Reclamation.Commands
{
    public class DeleteReclamationCommand:DeleteCommand
    {
    }
    public class DeleteReclamationCommandValidator : AbstractValidator<DeleteReclamationCommand>
    {
        public DeleteReclamationCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}
