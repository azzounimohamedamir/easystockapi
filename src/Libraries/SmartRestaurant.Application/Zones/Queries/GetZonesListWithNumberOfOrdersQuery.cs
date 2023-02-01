using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class GetZonesListWithNumberOfOrdersQuery : IRequest<IEnumerable<ZoneWithNumberOfOrdersDto>>
    {
        [SwaggerSchema(ReadOnly = true)] public string FoodBusinessId { get; set; }
    }
    public class GetZonesListWithNumberOfOrdersQueryValidator : AbstractValidator<GetZonesListWithNumberOfOrdersQuery>
    {
        public GetZonesListWithNumberOfOrdersQueryValidator()
        {
            RuleFor(foodBusiness => foodBusiness.FoodBusinessId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
