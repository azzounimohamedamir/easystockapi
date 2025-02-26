using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string RaisonSociale { get; set; }
        public string Email { get; set; }
        public string Addresse { get; set; }
        public string Tel { get; set; }
        public decimal Nrc { get; set; }
        public decimal Nif { get; set; }
        public decimal Nic { get; set; }

        public string Commerce { get; set; }
        public decimal Numarticle { get; set; }

        public decimal TotalCredits { get; set; }
        public decimal TotalAvances { get; set; }
        public bool IsBanned { get; set; }
        public bool IsDisabled { get; set; }

        public DateTime DateEcheance { get; set; }

    }
}
