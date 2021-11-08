using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Common.Validators
{
    public class OrderDishSupplementDtoValidator : AbstractValidator<OrderDishSupplementDto>
    {
        public OrderDishSupplementDtoValidator()
        {
            RuleFor(x => x.SupplementId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(x => x.Name)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .MaximumLength(200);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.EnergeticValue)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Description)
              .MaximumLength(500);
        }

    }
}
