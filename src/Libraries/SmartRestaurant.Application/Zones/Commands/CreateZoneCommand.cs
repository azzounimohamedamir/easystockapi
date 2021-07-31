using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.Zones.Commands
{
    public class CreateZoneCommand : IRequest<Created>
    {
        public Guid Id { get; set; }
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