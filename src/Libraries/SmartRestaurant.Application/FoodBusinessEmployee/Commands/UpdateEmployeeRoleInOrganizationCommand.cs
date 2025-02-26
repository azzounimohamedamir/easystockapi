using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class UpdateEmployeeRoleInOrganizationCommand : IRequest<Ok>
    {
        [JsonIgnore]
        public string UserId { get; set; }
        public string FoodBusinessId { get; set; }
        public string OldRole { get; set; }
        public string NewRole { get; set; }

    }

    public class
        UpdateEmployeeRoleInOrganizationCommandValidator : AbstractValidator<UpdateEmployeeRoleInOrganizationCommand>
    {
        public UpdateEmployeeRoleInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty.ToString())
                    .Must(ValidatorHelper.ValidateGuid).WithMessage("'UserId' must be a valid GUID");

            RuleFor(v => v.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty.ToString())
                    .Must(ValidatorHelper.ValidateGuid).WithMessage("'FoodBusinessId' must be a valid GUID");

            RuleFor(v => v.OldRole).NotEmpty()
                    .Must(ValidatorHelper.ValidateRoleForFoodBusinessStaff)
                    .WithMessage("'OldRole' for oraganization staff is invalide");

            RuleFor(v => v.NewRole).NotEmpty()
                  .Must(ValidatorHelper.ValidateRoleForFoodBusinessStaff)
                  .WithMessage("'NewRole' for oraganization staff is invalide");
        }
    }
}