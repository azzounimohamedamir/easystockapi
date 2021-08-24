using System;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class UserAcceptsInvitationToJoinOrganizationCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public class
        UserAcceptsInvitationToJoinOrganizationValidator : AbstractValidator<
            UserAcceptsInvitationToJoinOrganizationCommand>
    {
        public UserAcceptsInvitationToJoinOrganizationValidator()
        {
            RuleFor(invitedUser => invitedUser.Id).NotEmpty().NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'User Id' must be a valid GUID");

            RuleFor(invitedUser => invitedUser.Email).NotEmpty().Must(ValidatorHelper.ValidateEmail)
                .WithMessage("'Email' is invalide");

            RuleFor(invitedUser => invitedUser.Password).NotEmpty().Must(ValidatorHelper.ValidatePassword)
                .WithMessage("'Password' must have at least 6 characters");

            RuleFor(invitedUser => invitedUser.FullName).NotEmpty();
            RuleFor(invitedUser => invitedUser.PhoneNumber).NotEmpty();
            RuleFor(invitedUser => invitedUser.Token).NotEmpty();
        }
    }
}