using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Accounts.Commands
{
    public class ForgetPasswordCommand : IRequest<NoContent>
    {
        public string Email { get; set; }
    }

    public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordCommandValidator()
        {
            RuleFor(foodBusiness => foodBusiness.Email)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .MaximumLength(200)
               .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");

        }
    }
}
