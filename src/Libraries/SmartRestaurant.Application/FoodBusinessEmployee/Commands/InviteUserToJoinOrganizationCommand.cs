using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class InviteUserToJoinOrganizationCommand : CreateCommand
    {
        public List<string> FoodBusinessesIds { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }

    public class InviteUserToJoinOrganizationCommandValidator : AbstractValidator<InviteUserToJoinOrganizationCommand>
    {
       

        public InviteUserToJoinOrganizationCommandValidator()
        {
            RuleFor(invitation => invitation.FoodBusinessesIds).NotEmpty();
            RuleForEach(invitation => invitation.FoodBusinessesIds) 
                .ChildRules(foodBusinessId =>  foodBusinessId.RuleFor(x => x).NotEmpty().NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage($"'FoodBusinessId' must be a valid GUID"));

            RuleFor(invitedUser => invitedUser.Email).NotEmpty().Must(ValidatorHelper.ValidateEmail).WithMessage("'Email' is invalide");
           
            RuleFor(invitedUser => invitedUser.Roles).NotEmpty();
            RuleForEach(invitation => invitation.Roles)
              .ChildRules(role => role.RuleFor(x => x).NotEmpty().Must(ValidatorHelper.ValidateRoleForOraganizationStaff)
              .WithMessage($"'Role' for oraganization staff is invalide"));
        }


    }
}