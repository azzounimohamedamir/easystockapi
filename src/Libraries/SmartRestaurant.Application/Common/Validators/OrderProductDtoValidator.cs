using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Common.Validators
{
    public class OrderProductDtoValidator : AbstractValidator<OrderProductDto>
    {
        public OrderProductDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.EnergeticValue)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Description)
              .MaximumLength(500);

            RuleFor(x => x.TableNumber)
                .GreaterThan(0);

            RuleFor(x => x.ChairNumber)
                .GreaterThan(0)
                .LessThanOrEqualTo(99);

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .LessThanOrEqualTo(999);
        }

    }
}
