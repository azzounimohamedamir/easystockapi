using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Reglement_Acompte_Facture_Client
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid FactureId { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string Libelle { get; set; }

        public string Type { get; set; }
        public Facture Facture { get; set; }
        public Client Client { get; set; }
    }
}
