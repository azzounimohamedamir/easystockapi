using System;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.FoodBusinessClient.Commands
{
    public class UpdateFoodBusinessClientCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }
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
    }
    public class UpdateFoodBusinessClientCommandValidator : AbstractValidator<UpdateFoodBusinessClientCommand>
    {
        public UpdateFoodBusinessClientCommandValidator()
        {
            RuleFor(foodBusinessClient => foodBusinessClient.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

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
                .DependentRules(() =>
                {
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
            RuleFor(foodBusinessClient => foodBusinessClient.PhoneNumber)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .NotEmpty();

            RuleFor(foodBusinessClient => foodBusinessClient.Description)
               .MaximumLength(500);

            RuleFor(foodBusinessClient => foodBusinessClient.Website)
                .Must(ValidatorHelper.ValidateUrl).WithMessage("'{PropertyName}: {PropertyValue}' is invalide")
                .When(foodBusinessClient => !String.IsNullOrWhiteSpace(foodBusinessClient.Website));


        }
    }
}