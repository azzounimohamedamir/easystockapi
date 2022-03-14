using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Common.Validators
{
    public class BillDishCommandDtoValidator : AbstractValidator<BillDishCommandDto>
    {
        public BillDishCommandDtoValidator()
        {
            RuleFor(x => x.OrderDishId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0);
        }
    }
}
