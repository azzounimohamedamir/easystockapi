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

            RuleFor(x => x.ComboBoxContentTranslation)
                .NotEmpty().WithMessage("'Specification Items' can not be empty")
                .When(x => x.ContentType == ContentType.ComboBox);
            
            RuleForEach(dish => dish.ComboBoxContentTranslation)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("'OptionsTranslation' must not be empty")
              .SetValidator(new ComboBoxContentTranslationValidator())
              .When(dish => dish.ComboBoxContentTranslation != null &&
              dish.ContentType == ContentType.ComboBox);
            
            RuleFor(v => v.Names)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull()
              .DependentRules(() => {
                  RuleFor(v => v.Names.AR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.Names.EN)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.Names.FR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.Names.TR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.Names.RU)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotEmpty()
                   .MaximumLength(200);
              });

        }
    }
}
