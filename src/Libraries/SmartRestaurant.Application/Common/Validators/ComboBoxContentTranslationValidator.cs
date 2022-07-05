using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Validators
{
    public class ComboBoxContentTranslationValidator : AbstractValidator<TranslationItemDto>
    {
        public ComboBoxContentTranslationValidator()
        {
            RuleFor(x => x.Name)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty().WithMessage("'Option Name' can not be empty")
             .MaximumLength(200).WithMessage("'Option Name' can not have more than 200 characters");

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
