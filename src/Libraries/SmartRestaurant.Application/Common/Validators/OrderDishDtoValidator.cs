using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Common.Validators
{
    public class OrderDishCommandDtoValidator : AbstractValidator<OrderDishCommandDto>
    {
        public OrderDishCommandDtoValidator()
        {
            RuleFor(x => x.DishId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

       
       
          
            RuleFor(x => x.TableNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ChairNumber)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(99);

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .LessThanOrEqualTo(999);

            RuleForEach(x => x.Supplements)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Dish Supplement' must not be empty")
                .SetValidator(new OrderDishSupplementDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.Supplements) == false);

            RuleForEach(x => x.Specifications)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("'Dish Specification' must not be empty")
               .SetValidator(new OrderDishSpecificationDtoValidator())
               .When(x => ChecksHelper.IsEmptyList(x.Specifications) == false);

            RuleForEach(x => x.Ingredients)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("'Dish Ingredient' must not be empty")
               .SetValidator(new OrderDishIngredientDtoValidator())
               .When(x => ChecksHelper.IsEmptyList(x.Ingredients) == false);



        }

    }
}
