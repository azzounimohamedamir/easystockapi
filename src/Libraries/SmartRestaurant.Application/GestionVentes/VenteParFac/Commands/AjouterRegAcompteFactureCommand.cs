using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Commands
{
    public class AjouterRegAcompteFactureCommand : CreateCommand
    {

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid FactureId { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string Libelle { get; set; }
        public string Type { get; set; }

    }

    public class AjouterRegAcompteFactureCommandValidator : AbstractValidator<AjouterRegAcompteFactureCommand>
    {
        public AjouterRegAcompteFactureCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}