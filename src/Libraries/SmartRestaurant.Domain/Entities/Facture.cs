using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRestaurant.Domain.Entities
{
    public class Facture
    {
        public Guid Id { get; set; }
        public Guid BlId { get; set; }
        public Guid VcId { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }
        public string CodeF { get; set; }
        public DateTime Date { get; set; }
        public string Heure { get; set; }
        public int Caisse { get; set; }
        public decimal CouponPrice { get; set; }
        public string NomCaissier { get; set; }
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
        public List<FacProducts> FacProducts { get; set; }
        public List<FactureAvoir> FactureAvoirs { get; set; }
        public List<Reglement_Acompte_Facture_Client> Reglement_Acompte_Facture_Clients { get; set; }
        public string ConditionPaiement { get; set; }

        public long Rip { get; set; }
        public long Rib { get; set; }
        public bool IsDeleted { get; set; }
        public string PaymentMethod { get; set; }
    }
}
