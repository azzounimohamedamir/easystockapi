using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class VenteComptoirDto
    {
        public Guid Id { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }
        public DateTime Date { get; set; }
        public string Heure { get; set; }

        public decimal Remise { get; set; }
        public decimal MontantTotal { get; set; }
        public decimal MontantAprRemise { get; set; }
        public Guid VendeurId { get; set; }
        public List<VenteComptoirProducts> VenteComptoirIncludedProducts { get; set; }

        public int Caisse { get; set; }
        public string NomCaissier { get; set; }
        public decimal MontantTotalHT { get; set; }
        public decimal MontantTotalHTApresRemise { get; set; }
        public decimal MontantTotalTVA { get; set; }
        public decimal MontantTotalTTC { get; set; }
        public decimal Timbre { get; set; }
        public decimal RestTotal { get; set; }
        public decimal TotalReglement { get; set; }
        public string PaymentMethod { get; set; }

        public string Etat { get; set; }
        public decimal CouponPrice { get; set; }

        // Other properties as needed...

        // You may choose to include only relevant information about the client, not the entire client object
        public ClientDto Client { get; set; }

        // You may choose to include only relevant information about the products, not the entire list


    }
}
