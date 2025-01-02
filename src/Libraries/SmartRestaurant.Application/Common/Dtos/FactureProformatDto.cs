using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class FactureProformatDto
    {
        public Guid Id { get; set; }
        public string CodeFP { get; set; }
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
        public List<FacProProductsDto> FacProProducts { get; set; }
        public long Rip { get; set; }
        public long Rib { get; set; }

        public string PaymentMethod { get; set; }
    }
}
