using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.Users.Queries
{
    public class SetNewPasswordForFoodBusinessAdministratorCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }
        public string NewPassword { get; set; }
    }

    public class SetNewPasswordForFoodBusinessAdministratorCommandValidator : AbstractValidator<SetNewPasswordForFoodBusinessAdministratorCommand>
    {
        public SetNewPasswordForFoodBusinessAdministratorCommandValidator()
        {
            RuleFor(invitedUser => invitedUser.Id).NotEmpty().NotEqual(Guid.Empty.ToString())
                         .Must(ValidatorHelper.ValidateGuid).WithMessage("'User Id' must be a valid GUID");

            RuleFor(invitedUser => invitedUser.NewPassword).NotEmpty().Must(ValidatorHelper.ValidatePassword)
            .WithMessage("'Password' must have at least 6 characters");
        }
    }
}