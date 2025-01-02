using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class RetourProduitClient
    {

        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public int? Numero { get; set; }
        public string ReturnedFrom { get; set; }
        public DateTime? Date { get; set; }
        public string Heure { get; set; }
        public decimal RestTotal { get; set; }
        public decimal MontantTotalTTC { get; set; }
        public Guid ClientId { get; set; }
        public List<RetourProducts> RetourProducts { get; set; }

        public Client Client { get; set; }
    }
}
