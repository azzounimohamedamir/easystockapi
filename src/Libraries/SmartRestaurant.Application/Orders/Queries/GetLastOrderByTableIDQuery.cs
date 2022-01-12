using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class GetLastOrderByTableIDQuery : IRequest<OrderDto>
    {
        public string TableId { get; set; }
    }

    public class GetLastOrderByTableIDValidator : AbstractValidator<GetLastOrderByTableIDQuery>
    {
        public GetLastOrderByTableIDValidator()
        {
            RuleFor(dish => dish.TableId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}