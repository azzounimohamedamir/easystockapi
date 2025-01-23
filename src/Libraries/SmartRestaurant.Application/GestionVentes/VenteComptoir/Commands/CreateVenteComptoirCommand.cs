using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands
{
    public class CreateVenteComptoirCommand : CreateCommand
    {
        public decimal Remise { get; set; }
        public decimal MontantTotal { get; set; }
        public decimal MontantAprRemise { get; set; }
        public string VendeurId { get; set; }
        public int Caisse { get; set; }
        public string NomCaissier { get; set; }
        public List<VenteComptoirProducts> VenteComptoirIncludedProducts { get; set; }
        public string NomVehicule { get; set; }
        public string MatriculeVeh { get; set; }
        public string Conducteur { get; set; }
        public string ConditionDePaiment { get; set; }
        public string LieuLivraison { get; set; }

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
        public string Etat { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public long Rip { get; set; }
        public long Rib { get; set; }

        public string PaymentMethod { get; set; }


    }

    public class CreateVenteComptoirCommandValidator : AbstractValidator<CreateVenteComptoirCommand>
    {
        public CreateVenteComptoirCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           

        }
    }
}