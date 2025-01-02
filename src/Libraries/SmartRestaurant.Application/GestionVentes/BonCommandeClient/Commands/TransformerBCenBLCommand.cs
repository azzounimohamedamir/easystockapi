using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Commands
{
    public class TransformerBCenBLCommand: IRequest<Created>
    {
        public Client Client { get; set; }
        public Domain.Entities.BonCommandeClient Bon { get; set; }
    }
    public class TransformerBCenBLCommandValidator : AbstractValidator<TransformerBCenBLCommand>
    {
        public TransformerBCenBLCommandValidator()
        {
            RuleFor(m => m.Client.Id).NotEmpty().Must(id => id != Guid.Empty);
            RuleFor(m => m.Bon.Id).NotEmpty().Must(id => id != Guid.Empty);


        }
    }
}
