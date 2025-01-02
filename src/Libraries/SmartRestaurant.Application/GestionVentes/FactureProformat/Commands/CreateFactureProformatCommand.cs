using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Commands
{
    public class CreateFactureProformatCommand : CreateCommand
    {

        public int Numero { get; set; }
        public DateTime Date { get; set; }
        public string Heure { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateFermuture { get; set; }
        public DateTime DateEcheance { get; set; }

        public decimal MontantTotalHT { get; set; }
        public decimal MontantTotalHTApresRemise { get; set; }
        public decimal MontantTotalTVA { get; set; }
        public decimal MontantTotalTTC { get; set; }
        public decimal Timbre { get; set; }
        public decimal RestTotal { get; set; }
        public decimal TotalReglement { get; set; }

        public decimal Remise { get; set; }
        public string Etat { get; set; }
        public Guid VendeurId { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public List<FacProProducts> FacProProducts { get; set; }
        public long Rip { get; set; }
        public long Rib { get; set; }

        public string PaymentMethod { get; set; }

    }

    public class CreateFactureProformatCommandValidator : AbstractValidator<CreateFactureProformatCommand>
    {
        public CreateFactureProformatCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           

        }
    }
}