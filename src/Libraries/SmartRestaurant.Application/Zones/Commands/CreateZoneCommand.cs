using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Zones.Commands
{
    public class CreateZoneCommand : CreateCommand
    {
        public string ZoneTitle { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class CreateZoneCommandValidator : AbstractValidator<CreateZoneCommand>
    {
        public CreateZoneCommandValidator()
        {
            RuleFor(v => v.ZoneTitle).MaximumLength(200).NotEmpty();
            RuleFor(v => v.FoodBusinessId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}