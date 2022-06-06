using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Validators;
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
                .SetValidator(new IllnessIngedientValidator())
                .NotEmpty().WithMessage("'Ingredient' must not be empty")
                .When(illness => illness.Ingredients != null);
        }
    }
}
