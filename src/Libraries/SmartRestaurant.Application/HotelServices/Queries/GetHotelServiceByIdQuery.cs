using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.HotelServices.Queries
{
    public class GetHotelServiceByIdQuery : IRequest<HotelServiceDto>
    {
        public string Id { get; set; }
    }

    public class GetHotelServiceByIdQueryValidator : AbstractValidator<GetHotelServiceByIdQuery>
    {
        public GetHotelServiceByIdQueryValidator()
        {
            RuleFor(v => v.Id).Cascade(CascadeMode.StopOnFirstFailure)
          .NotEqual(Guid.Empty.ToString())
          .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
          .When(v => v.Id != null);
        }
    }
}
