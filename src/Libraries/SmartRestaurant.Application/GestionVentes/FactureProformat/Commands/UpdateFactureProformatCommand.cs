using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Commands
{
    public class UpdateFactureProformatCommand : UpdateCommand
    {
        public int Numero { get; set; }
        public DateTime Date { get; set; }
        public string Heure { get; set; }
        public string CreatedBy { get; set; }

        public decimal MontantTotalHT { get; set; }
        public decimal MontantTotalTVA { get; set; }
        public decimal MontantTotalTTC { get; set; }
        public decimal TotalReglement { get; set; }

        public decimal Timbre { get; set; }
        public Guid VendeurId { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public List<FacProProducts> FacProProducts { get; set; }
    }

    public class UpdateFactureProformatCommandValidator : AbstractValidator<UpdateFactureProformatCommand>
    {
        public UpdateFactureProformatCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}