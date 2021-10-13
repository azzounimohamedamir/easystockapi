using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.FoodBusinessClient.Commands
{
    public class CreateFoodBusinessClientCommand : CreateCommand
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string ManagerId { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public string FoodBusinessId { get; set; }
    }

    public class CreateFoodBusinessClientCommandValidator : AbstractValidator<CreateFoodBusinessClientCommand>
    {
        public CreateFoodBusinessClientCommandValidator()
        {
            RuleFor(foodBusinessClient => foodBusinessClient.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(foodBusinessClient => foodBusinessClient.ManagerId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(foodBusinessClient => foodBusinessClient.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200)
                .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");

            RuleFor(foodBusinessClient => foodBusinessClient.Address)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .DependentRules(() => {
                    RuleFor(foodBusinessClient => foodBusinessClient.Address.StreetAddress)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(foodBusinessClient => foodBusinessClient.Address.City)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(foodBusinessClient => foodBusinessClient.Address.Country)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);
                });

            RuleFor(foodBusinessClient => foodBusinessClient.Description)
               .MaximumLength(500);

            RuleFor(foodBusinessClient => foodBusinessClient.Website)
                .Must(ValidatorHelper.ValidateUrl).WithMessage("'{PropertyName}: {PropertyValue}' is invalide")
                .When(foodBusiness => !String.IsNullOrWhiteSpace(foodBusiness.Website));

            RuleFor(foodBusinessClient => foodBusinessClient.FoodBusinessId)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .NotEqual(Guid.Empty.ToString())
             .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
