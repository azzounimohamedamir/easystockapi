using System;

namespace SmartRestaurant.Domain.Entities
{
    public class CreditClients
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public decimal MontantCredit { get; set; }
        public DateTime DateCredit { get; set; }
        public DateTime DateEcheance { get; set; }
        public Client Client { get; set; }
    }
}
