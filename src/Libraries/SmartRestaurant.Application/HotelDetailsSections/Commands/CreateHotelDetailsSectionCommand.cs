using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;

namespace SmartRestaurant.Application.HotelDetailsSections.Commands
{
    public class CreateHotelDetailsSectionCommand : CreateCommand
    {
             public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public Guid HotelId { get; set; }
    }

    public class CreateHotelDetailsSectionCommandValidator : AbstractValidator<CreateHotelDetailsSectionCommand>
    {
        public CreateHotelDetailsSectionCommandValidator()
        {
            RuleFor(m => m.HotelId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID");
           
            RuleFor(m => m.Description)
               .MaximumLength(1000);
        }
    }
}
