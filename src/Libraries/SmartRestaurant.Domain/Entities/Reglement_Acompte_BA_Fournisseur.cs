using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Reglement_Acompte_BA_Fournisseur
    {
        public Guid Id { get; set; }
        public Guid FournisseurId { get; set; }
        public Guid BAId { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string Libelle { get; set; }

        public string Type { get; set; }
        public BonAchats Ba { get; set; }
        public Fournisseur Fournisseur { get; set; }
    }
}
