using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Buildings.Commands
{
    public class CreateBuildingCommand : CreateCommand
    {
        public string Name { get; set; }
        //public byte[] Picture { get; set; }
        public IFormFile Picture { get; set; }
        public Guid HotelId { get; set; }
    }

    public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingCommand>
    {
        public CreateBuildingCommandValidator()
        {
            RuleFor(building => building.Picture);

            RuleFor(building => building.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");

            RuleFor(building => building.HotelId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty()
                .WithMessage("'{PropertyName}' must be a valid GUID");

        }
    }
}
