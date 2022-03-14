using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Common.Validators
{
    public class DishSupplementCreateDtoValidator : AbstractValidator<DishSupplementCreateDto>
    {
        public DishSupplementCreateDtoValidator()
        {
            RuleFor(x => x.SupplementId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
