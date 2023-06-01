using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class RemoveEmployeeFromOrganizationCommand : IRequest<Ok>
    {
        public EmployeesType EmployeesType { get; set; }
        public string UserId { get; set; }
        public List<string> businessesIds { get; set; }
    }

    public class
        RemoveEmployeeFromInOrganizationCommandValidator : AbstractValidator<RemoveEmployeeFromOrganizationCommand>
    {
        public RemoveEmployeeFromInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty.ToString());
            RuleFor(v => v.businessesIds).NotEmpty();
            RuleForEach(v => v.businessesIds)
                .ChildRules(c => c.RuleFor(x => x).NotEmpty().NotEqual(Guid.Empty.ToString())
                    .Must(ValidatorHelper.ValidateGuid).WithMessage("'FoodBusinessId' must be a valid GUID"));
        }
    }
}