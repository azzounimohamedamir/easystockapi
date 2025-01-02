using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class ClientFidelite
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public int Points { get; set; } // Nombre de points de fidélité du client
        public DateTime DateInscription { get; set; }
        public decimal Withdraw { get; set; }


        // Relations
        public Guid NiveauFideliteId { get; set; }
        public NiveauFidelite NiveauFidelite { get; set; }

    }
}
