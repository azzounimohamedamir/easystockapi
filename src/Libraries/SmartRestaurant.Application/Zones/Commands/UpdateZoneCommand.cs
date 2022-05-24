using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;

namespace SmartRestaurant.Application.Zones.Commands
{
    public class UpdateZoneCommand : UpdateCommand
    {
        public string ZoneTitle { get; set; }
        public NamesDto Names { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class UpdateZoneCommandValidator : AbstractValidator<UpdateZoneCommand>
    {
        public UpdateZoneCommandValidator()
        {
            RuleFor(v => v.ZoneTitle).MaximumLength(200).NotEmpty();
            RuleFor(v => v.FoodBusinessId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(m => m.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
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