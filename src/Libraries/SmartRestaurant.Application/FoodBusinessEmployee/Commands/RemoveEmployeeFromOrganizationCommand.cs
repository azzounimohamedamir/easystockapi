using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class RemoveEmployeeFromOrganizationCommand : IRequest<Ok>
    {
        public string UserId { get; set; }
        public List<string> FoodBusinessesIds { get; set; }
    }

    public class RemoveEmployeeFromInOrganizationCommandValidator : AbstractValidator<RemoveEmployeeFromOrganizationCommand>
    {
        public RemoveEmployeeFromInOrganizationCommandValidator()
        {

            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty.ToString());
            RuleFor(v => v.FoodBusinessesIds).NotEmpty();
            RuleForEach(v => v.FoodBusinessesIds)
               .ChildRules(c => c.RuleFor(x => x).NotEmpty().NotEqual(Guid.Empty.ToString())
               .Must(ValidatorHelper.ValidateGuid).WithMessage($"'FoodBusinessId' must be a valid GUID"));
        }
    }
}