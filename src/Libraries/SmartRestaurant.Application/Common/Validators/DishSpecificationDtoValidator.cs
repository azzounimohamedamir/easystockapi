using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Validators
{
    public class DishSpecificationDtoValidator : AbstractValidator<DishSpecificationDto>
    {
        public DishSpecificationDtoValidator()
        {
            RuleFor(x => x.ContentType)
                .IsInEnum();

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Specification Title' can not be empty")
                .MaximumLength(200).WithMessage("'Specification Title' can not have more than 200 characters");

            RuleFor(x => x.ComboBoxContent)
                .NotEmpty().WithMessage("'Specification Items' can not be empty")
                .When(x => x.ContentType == ContentType.ComboBox);

            RuleForEach(x => x.ComboBoxContent)
                .ChildRules(item => item.RuleFor(x => x)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("'Specification Item' can not be empty")
                    .MaximumLength(200).WithMessage("'Specification Item' can not have more than 200 characters"))
                .When(x => x.ContentType == ContentType.ComboBox);
        }
    }
}
