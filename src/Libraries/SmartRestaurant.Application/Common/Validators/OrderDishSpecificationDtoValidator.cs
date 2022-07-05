using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Validators
{
    public class OrderDishSpecificationDtoValidator : AbstractValidator<OrderDishSpecificationDto>
    {
        public OrderDishSpecificationDtoValidator()
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

            RuleForEach(x => x.ComboBoxContentTranslation)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("'OptionsTranslation' must not be empty")
              .SetValidator(new ComboBoxContentTranslationValidator())
              .When(x => x.ComboBoxContentTranslation != null && 
              x.ContentType == ContentType.ComboBox);

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
