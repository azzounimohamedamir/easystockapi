using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class GetZonesListWithTablesQuery : IRequest<IEnumerable<ZoneWithTablesDto>>
    {
        [SwaggerSchema(ReadOnly = true)] public string FoodBusinessId { get; set; }
    }
    public class GetZonesListWithTablesQueryValidator : AbstractValidator<GetZonesListWithTablesQuery>
    {
        public GetZonesListWithTablesQueryValidator()
        {
            RuleFor(foodBusiness => foodBusiness.FoodBusinessId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
