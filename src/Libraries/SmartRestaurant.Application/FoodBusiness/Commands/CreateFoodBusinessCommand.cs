using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class CreateFoodBusinessCommand : CreateCommand
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFriendly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public List<string> Tags { get; set; }
        public string Website { get; set; }
        public string FoodBusinessAdministratorId { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public FoodBusinessCategory FoodBusinessCategory { get; set; }
        public int FourDigitCode { get; set; }
    }


    public class CreateFoodBusinessCommandValidator : AbstractValidator<CreateFoodBusinessCommand>
    {
        public CreateFoodBusinessCommandValidator()
        {
            RuleFor(foodBusiness => foodBusiness.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(invitedUser => invitedUser.FoodBusinessAdministratorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(foodBusiness => foodBusiness.Email)
                .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide")
                .When(foodBusiness => !String.IsNullOrWhiteSpace(foodBusiness.Email));

            RuleFor(foodBusiness => foodBusiness.Website)
                .Must(ValidatorHelper.ValidateUrl).WithMessage("'{PropertyName}: {PropertyValue}' is invalide")
                .When(foodBusiness => !String.IsNullOrWhiteSpace(foodBusiness.Website));

            RuleFor(foodBusiness => foodBusiness.FourDigitCode)
                .LessThanOrEqualTo(9999);
        }
    }
}