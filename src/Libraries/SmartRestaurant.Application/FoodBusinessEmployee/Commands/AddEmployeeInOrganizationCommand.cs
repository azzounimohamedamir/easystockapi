using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using System;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class AddEmployeeInOrganizationCommand : IRequest<Ok>
    {
        public Guid UserId { get; set; }
        public Guid FoodBusinessId { get; set; }
        public string Role { get; set; }
    }

    public class AddEmployeeInOrganizationCommandValidator : AbstractValidator<AddEmployeeInOrganizationCommand>
    {
        public AddEmployeeInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(v => v.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}