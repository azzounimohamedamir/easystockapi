using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Addresse { get; set; }
        public decimal Nrc { get; set; }
        public decimal Nif { get; set; }
        public decimal Nic { get; set; }

        public string OldCredit { get; set; }
        public DateTime DateCreditOrAvancement { get; set; }
        public DateTime DateEcheance { get; set; }

    }

}
