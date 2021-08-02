using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class UpdateEmployeeRoleInOrganizationCommand : IRequest<Ok>
    {
        public Guid UserId { get; set; }
        public Guid FoodBusinessId { get; set; }
        public string Role { get; set; }
    }

    public class
        UpdateEmployeeRoleInOrganizationCommandValidator : AbstractValidator<UpdateEmployeeRoleInOrganizationCommand>
    {
        public UpdateEmployeeRoleInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(v => v.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}