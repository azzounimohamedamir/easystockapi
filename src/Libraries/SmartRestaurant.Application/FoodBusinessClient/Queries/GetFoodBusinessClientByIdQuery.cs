using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinessClientByIdQuery : IRequest<FoodBusinessClientDto>
    {
        public string FoodBusinessClientId { get; set; }
    }
    public class GetFoodBusinessClientByIdQueryValidator : AbstractValidator<GetFoodBusinessClientByIdQuery>
    {
        public GetFoodBusinessClientByIdQueryValidator()
        {
            RuleFor(foodBusinessClient => foodBusinessClient.FoodBusinessClientId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
