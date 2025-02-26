using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands
{
    public class TransformerVCenBLCommand : IRequest<Created>
    {
        public Client Client { get; set; }
        public Domain.Entities.VenteComptoir Vc { get; set; }
    }
    public class TransformerVCenBLCommandValidator : AbstractValidator<TransformerVCenBLCommand>
    {
        public TransformerVCenBLCommandValidator()
        {
            RuleFor(m => m.Client.Id).NotEmpty().Must(id => id != Guid.Empty);
            RuleFor(m => m.Vc.Id).NotEmpty().Must(id => id != Guid.Empty);


        }
    }
}
