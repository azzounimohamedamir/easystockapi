using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.Validators;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class UpdateIllnessCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public string Name { get; set; }
        public NamesDto Names { get; set; }
        public List<IngredientIllnessDto> Ingredients { get; set; }
    }

    public class UpdateIllnessCommandValidator : AbstractValidator<UpdateIllnessCommand>
    {
        public UpdateIllnessCommandValidator()
        {
            RuleFor(illness => illness.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(illness => illness.Name)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .MaximumLength(200);

            RuleForEach(illness => illness.Ingredients)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .SetValidator(new IllnessIngedientValidator())
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
