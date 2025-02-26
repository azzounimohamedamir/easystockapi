using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class Reglement_Acompte_Facture_Client_Dto
    {
        public Guid Id { get; set; }
        public Guid EmployeId { get; set; }
        public Guid FactureId { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string Libelle { get; set; }

        public string Type { get; set; }
        public FactureDto Facture { get; set; }
        public ClientDto Client { get; set; }
    }

}
