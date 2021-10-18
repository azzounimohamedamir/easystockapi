using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinesClientListByFoodBusinessIdQuery : IRequest<IEnumerable<FoodBusinessClientDto>>
    {
        public string FoodBusinessId { get; set; }
    }

    public class GetFoodBusinesClientListByFoodBusinessIdQueryValidator : AbstractValidator<GetFoodBusinesClientListByFoodBusinessIdQuery>
    {
        public GetFoodBusinesClientListByFoodBusinessIdQueryValidator()
        {
            RuleFor(foodBusinessClient => foodBusinessClient.FoodBusinessId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

        }
    }
}
