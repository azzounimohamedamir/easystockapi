using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.TypeReclamation.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.ServiceTechniqueDestination.Commands
{
    public class DeleteServiceTechniqueCommand:DeleteCommand
    {

    }
    public class DeleteServiceTechniqueCommandValidator : AbstractValidator<DeleteServiceTechniqueCommand>
    {
        public DeleteServiceTechniqueCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}
