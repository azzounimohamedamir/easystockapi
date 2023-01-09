using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.HotelServices.Queries
{
    public class GetAllHotelServicesBySectionIdQuery:IRequest<List<HotelServiceDto>>
    {
        public string HotelSectionId { get; set; }
    }

    public class GetAllHotelServicesBySectionIdQueryValidator : AbstractValidator<GetAllHotelServicesBySectionIdQuery>
    {
        public GetAllHotelServicesBySectionIdQueryValidator()
        {
            RuleFor(v => v.HotelSectionId).Cascade(CascadeMode.StopOnFirstFailure)
            .NotEqual(Guid.Empty.ToString())
            .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
            .When(v => v.HotelSectionId != null); 
        }
    }
}
