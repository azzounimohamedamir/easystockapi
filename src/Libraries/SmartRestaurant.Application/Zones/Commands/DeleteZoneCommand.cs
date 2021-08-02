using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Zones.Commands
{
    public class DeleteZoneCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
    }

    public class DeleteZoneCommandValidator : AbstractValidator<DeleteZoneCommand>
    {
        public DeleteZoneCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}