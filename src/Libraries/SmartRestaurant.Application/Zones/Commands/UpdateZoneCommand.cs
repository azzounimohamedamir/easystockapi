using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;


namespace SmartRestaurant.Application.Zones.Commands
{
    public class UpdateZoneCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
        public string ZoneTitle { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class UpdateZoneCommandValidator : AbstractValidator<UpdateZoneCommand>
    {
        public UpdateZoneCommandValidator()
        {
            RuleFor(v => v.ZoneTitle).MaximumLength(200).NotEmpty();
            RuleFor(v => v.FoodBusinessId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(m => m.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}