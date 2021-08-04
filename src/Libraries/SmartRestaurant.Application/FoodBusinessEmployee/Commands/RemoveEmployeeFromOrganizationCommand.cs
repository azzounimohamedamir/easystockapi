using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class RemoveEmployeeFromOrganizationCommand : IRequest<Ok>
    {
        public Guid UserId { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class
        RemoveEmployeeFromInOrganizationCommandValidator : AbstractValidator<RemoveEmployeeFromOrganizationCommand>
    {
        public RemoveEmployeeFromInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(v => v.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}