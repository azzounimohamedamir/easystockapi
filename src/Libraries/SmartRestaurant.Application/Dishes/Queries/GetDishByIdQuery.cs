using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class GetDishByIdQuery : IRequest<DishDto>
    {
        public string Id { get; set; }
    }

    public class GetDishByIdQueryValidator : AbstractValidator<GetDishByIdQuery>
    {
        public GetDishByIdQueryValidator()
        {
            RuleFor(dish => dish.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}