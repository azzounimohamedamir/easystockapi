using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.HotelDetailsSections.Queries
{
    public class GetHotelDetailsSectionByIdQuery : IRequest<HotelDetailsSectionDto>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class GetHotelDetailsSectionByIdQueryValidator : AbstractValidator<GetHotelDetailsSectionByIdQuery>
    {
        public GetHotelDetailsSectionByIdQueryValidator()
        {
            RuleFor(section => section.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
