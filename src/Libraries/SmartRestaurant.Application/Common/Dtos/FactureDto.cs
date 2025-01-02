using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class FactureDto
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public string CodeF { get; set; }
        public DateTime Date { get; set; }
        public string Heure { get; set; }
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

        public decimal Remise { get; set; }
        public string Etat { get; set; }
        public decimal CouponPrice { get; set; }

        // Other properties as needed...

        // You may choose to include only relevant information about the client, not the entire client object
        public ClientDto Client { get; set; }

        // You may choose to include only relevant information about the products, not the entire list
        public List<FacProductsDto> FacProducts { get; set; }
    }
}
