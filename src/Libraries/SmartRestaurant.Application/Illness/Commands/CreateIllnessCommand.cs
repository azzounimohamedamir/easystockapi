using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class CreateIllnessCommand : CreateCommand
    {
        public string Name { get; set; }
        public NamesDto Names { get; set; }
        public List<IngredientIllnessDto> Ingredients { get; set; }
    }


    public class CreateIllnessCommandValidator : AbstractValidator<CreateIllnessCommand>
    {
        public CreateIllnessCommandValidator()
        {
            RuleFor(illness => illness.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);
            RuleForEach(illness => illness.Ingredients)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Ingredient' must not be empty")
                .When(illness => illness.Ingredients != null);
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
