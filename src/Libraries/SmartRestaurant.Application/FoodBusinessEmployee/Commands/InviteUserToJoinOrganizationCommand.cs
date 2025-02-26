using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;
using System.Collections.Generic;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class InviteUserToJoinOrganizationCommand : CreateCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }

    }

    public class InviteUserToJoinOrganizationCommandValidator : AbstractValidator<InviteUserToJoinOrganizationCommand>
    {
        public InviteUserToJoinOrganizationCommandValidator()
        {


            RuleFor(invitedUser => invitedUser.Email).NotEmpty().Must(ValidatorHelper.ValidateEmail)
                .WithMessage("'Email' is invalide");






            RuleFor(invitedUser => invitedUser.Roles).NotEmpty();

        }
    }
}