using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Commands
{
    public class CreateFactureCommand : CreateCommand
    {

        public int Numero { get; set; }
        public DateTime Date { get; set; }
        public string Heure { get; set; }
        public int Caisse { get; set; }
        public string NomCaissier { get; set; }
        public DateTime DateFermuture { get; set; }
        public DateTime DateEcheance { get; set; }
        public bool IsDeleted { get; set; }
        public decimal MontantTotalHT { get; set; }
        public decimal MontantTotalHTApresRemise { get; set; }
        public decimal MontantTotalTVA { get; set; }
        public decimal MontantTotalTTC { get; set; }
        public decimal Timbre { get; set; }
        public decimal RestTotal { get; set; }
        public decimal TotalReglement { get; set; }
        public decimal CouponPrice { get; set; }
        public decimal Remise { get; set; }
        public string Etat { get; set; }
        public Guid VendeurId { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public List<FacProducts> FacProducts { get; set; }
        public long Rip { get; set; }
        public long Rib { get; set; }

        public string PaymentMethod { get; set; }

    }

    public class CreateFactureCommandValidator : AbstractValidator<CreateFactureCommand>
    {
        public CreateFactureCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           

        }
    }
}