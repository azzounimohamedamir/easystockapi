using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Commands
{
    public class TransformerBCFenBACommand: IRequest<Created>
    {
        public Client Employe { get; set; }
        public Domain.Entities.BonCommandeFournisseur Bon { get; set; }
    }
    public class TransformerBCFenBACommandValidator : AbstractValidator<TransformerBCFenBACommand>
    {
        public TransformerBCFenBACommandValidator()
        {
            RuleFor(m => m.Employe.Id).NotEmpty().Must(id => id != Guid.Empty);
            RuleFor(m => m.Bon.Id).NotEmpty().Must(id => id != Guid.Empty);


        }
    }
}
