using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Application.Hotels.Commands
{
    public class CreateHotelCommand : CreateCommand
    {
        public string FoodBusinessAdministratorId { get; set; }
        public string ImagUrl { get; set; }
        public IFormFile Picture { get; set; }

        public string Name { get; set; }
        public Names Names { get; set; }

        public int? NRC { get; set; } 
        public int? NIF { get; set; }
        public int? NIS { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }

          public OdooDto Odoo { get; set; }
        public string? Website { get; set; }
        public string? YoutubeLink { get; set; }
    }

    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().MinimumLength(5);
            RuleFor(hotel => hotel.ImagUrl)
                .NotEmpty().MinimumLength(10);
            RuleFor(hotel => hotel.Picture)
                .NotEmpty();



            RuleFor(hotel => hotel.FoodBusinessAdministratorId)
               .NotNull();

            RuleFor(hotel => hotel.Email)
              .Cascade(CascadeMode.StopOnFirstFailure)
              
              .MaximumLength(200)
              .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");

            RuleFor(hotel => hotel.Address)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull();
                    RuleFor(hotel => hotel.Address.StreetAddress)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(hotel => hotel.Address.City)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(hotel => hotel.Address.Country)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);
            RuleFor(hotel => hotel.Address.GeoPosition.Longitude)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);
            RuleFor(hotel => hotel.Address.GeoPosition.Latitude)
                      .Cascade(CascadeMode.StopOnFirstFailure)
                      .NotEmpty()
                      .MaximumLength(200);


            RuleFor(hotel => hotel.Description)
               .MaximumLength(500);

            RuleFor(hotel => hotel.Website)
                .Must(ValidatorHelper.ValidateUrl).WithMessage("'{PropertyName}: {PropertyValue}' is invalide")
                .When(hotel => !String.IsNullOrWhiteSpace(hotel.Website));
            RuleFor(hotel => hotel.YoutubeLink)
                      .Cascade(CascadeMode.StopOnFirstFailure)
                      .NotEmpty()
                      .MaximumLength(200);

                    



        }

    }
}
