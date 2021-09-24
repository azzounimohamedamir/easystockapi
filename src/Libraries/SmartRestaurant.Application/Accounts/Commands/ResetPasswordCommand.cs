using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;

namespace SmartRestaurant.Application.Accounts.Commands
{
    public class ResetPasswordCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public class
        ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(invitedUser => invitedUser.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(invitedUser => invitedUser.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidatorHelper.ValidatePassword).WithMessage("'{PropertyName}' must have at least 6 characters");

            RuleFor(invitedUser => invitedUser.Token)
                .NotEmpty();
        }
    }
}
