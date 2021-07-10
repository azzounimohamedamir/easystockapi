using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Zones.Commands
{
    public class UpdateZoneCommand : SmartRestaurantCommand
    {
        public string ZoneTitle { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class UpdateZoneCommandValidator : AbstractValidator<UpdateZoneCommand>
    {
        public UpdateZoneCommandValidator()
        {
            RuleFor(v => v.ZoneTitle).MaximumLength(200).NotEmpty();
            RuleFor(v => v.FoodBusinessId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(m => m.CmdId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}