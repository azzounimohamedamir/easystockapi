using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinessClientByManagerIdQuery : IRequest<FoodBusinessClientDto>
    {
        public string FoodBusinessClientManagerId { get; set; }
    }
    public class GetFoodBusinessClientByManagerIdQueryValidator : AbstractValidator<GetFoodBusinessClientByManagerIdQuery>
    {
        public GetFoodBusinessClientByManagerIdQueryValidator()
        {
            RuleFor(foodBusinessClient => foodBusinessClient.FoodBusinessClientManagerId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
