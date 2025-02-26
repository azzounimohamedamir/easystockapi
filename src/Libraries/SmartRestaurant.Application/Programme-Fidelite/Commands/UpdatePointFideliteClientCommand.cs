using FluentValidation;
using MediatR;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.ProgrammeFidelite.Commands
{
    public class UpdatePointFideliteClientCommand : IRequest<ClientFidelite>
    {

        public Guid ClientId { get; set; }
        public decimal MontantFacture { get; set; }

    }

    public class UpdatePointFideliteClientCommandValidator : AbstractValidator<UpdatePointFideliteClientCommand>
    {
        public UpdatePointFideliteClientCommandValidator()
        {
            RuleFor(m => m.ClientId).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}