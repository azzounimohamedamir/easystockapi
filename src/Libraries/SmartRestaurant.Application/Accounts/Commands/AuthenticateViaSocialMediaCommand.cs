using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Accounts.Commands
{
    public class AuthenticateViaSocialMediaCommand : IRequest<LoginResponseDto>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string AuthToken { get; set; }
        public string IdToken { get; set; }
        public string Provider { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
    }

    public class AuthenticateViaSocialMediaCommandValidator : AbstractValidator<AuthenticateViaSocialMediaCommand>
    {
        public AuthenticateViaSocialMediaCommandValidator()
        {
            RuleFor(foodBusiness => foodBusiness.Email)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .MaximumLength(200)
              .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");

            RuleFor(foodBusiness => foodBusiness.Name)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .MaximumLength(200);
        }
    }
}
