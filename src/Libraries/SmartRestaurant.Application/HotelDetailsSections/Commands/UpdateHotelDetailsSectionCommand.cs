using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.HotelDetailsSections.Commands
{
    public class UpdateHotelDetailsSectionCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string hotelSetionId { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }

        public string HotelId { get; set; }
    }

    public class UpdateHotelDetailsSectionCommandValidator : AbstractValidator<UpdateHotelDetailsSectionCommand>
    {
        public UpdateHotelDetailsSectionCommandValidator()
        {
            RuleFor(section => section.hotelSetionId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(section => section.Picture)
                .NotEmpty();


            RuleFor(m => m.Description)
               .MaximumLength(1000);
        }
    }

}
