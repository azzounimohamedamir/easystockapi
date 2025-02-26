using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands
{
    public class TransformerBLenFactureCommand : IRequest<Created>
    {
        public Client Client { get; set; }
        public Domain.Entities.Bl Bl { get; set; }
    }
    public class TransformerBLenFactureCommandValidator : AbstractValidator<TransformerBLenFactureCommand>
    {
        public TransformerBLenFactureCommandValidator()
        {
            RuleFor(m => m.Client.Id).NotEmpty().Must(id => id != Guid.Empty);
            RuleFor(m => m.Bl.Id).NotEmpty().Must(id => id != Guid.Empty);


        }
    }
}
