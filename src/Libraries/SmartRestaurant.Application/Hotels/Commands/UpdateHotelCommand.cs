using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Hotels.Commands
{
    public class UpdateHotelCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }

        public string FoodBusinessAdministratorId { get; set; }
        public string ImagUrl { get; set; }

        public IFormFile Picture { get; set; }

        public string Name { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Website { get; set; }
        public string YoutubeLink { get; set; }

        public OdooDto Odoo { get; set; }

    }

    public class UpdateHotelCommandValidator : AbstractValidator<UpdateHotelCommand>
    {
        public UpdateHotelCommandValidator()
        {
            RuleFor(hotel => hotel.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
            
                RuleFor(m => m.Name)
                    .NotEmpty().MinimumLength(5);
                RuleFor(hotel => hotel.ImagUrl)
                    .NotEmpty().MinimumLength(10);




                RuleFor(hotel => hotel.Email)
                  .Cascade(CascadeMode.StopOnFirstFailure)

                  .MaximumLength(200)
                  .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");

                RuleFor(hotel => hotel.Address)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull();
                RuleFor(hotel => hotel.Address.StreetAddress)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .MaximumLength(200);

                RuleFor(hotel => hotel.Address.City)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .MaximumLength(200);

                RuleFor(hotel => hotel.Address.Country)
                   .Cascade(CascadeMode.StopOnFirstFailure)
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

                        RuleFor(foodBusiness => foodBusiness.Odoo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .DependentRules(() => {
                    RuleFor(foodBusiness => foodBusiness.Odoo.Url)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(foodBusiness => foodBusiness.Odoo.Username)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(foodBusiness => foodBusiness.Odoo.Password)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);
                          RuleFor(foodBusiness => foodBusiness.Odoo.Db)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);
                });


        }
        }
}