using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public string Id { get; set; }
    }

    public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdQueryValidator()
        {
            RuleFor(dish => dish.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}