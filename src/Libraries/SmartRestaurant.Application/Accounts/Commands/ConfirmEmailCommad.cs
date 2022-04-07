using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;

namespace SmartRestaurant.Application.Accounts.Commands
{
    public class ConfirmEmailCommad : IRequest<NoContent>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
    }
    public class ConfirmEmailCommadValidator : AbstractValidator<ConfirmEmailCommad>
    {
        public ConfirmEmailCommadValidator()
        {
            RuleFor(user => user.UserId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(user => user.Token)
                .NotEmpty();

            RuleFor(user => user.FullName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .MaximumLength(200);
        }
    }
}