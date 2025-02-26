using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ClientFideliteDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public int Points { get; set; } // Nombre de points de fidélité du client
        public DateTime DateInscription { get; set; }

        // Relations
        public decimal Withdraw { get; set; }

        public Guid NiveauFideliteId { get; set; }
        public NiveauFideliteDto NiveauFidelite { get; set; }
    }

}
