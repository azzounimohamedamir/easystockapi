using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class RetourProductsAvoirDto
    {
        public Guid Id { get; set; }
        public string Image { get; set; }

        public string Designation { get; set; }
        public decimal Qte { get; set; }
        public decimal MontantHT { get; set; }
        public decimal MontantTVA { get; set; }
        public decimal MontantTTC { get; set; }

        public decimal Puv { get; set; }
        public Guid FactureAvoirId { get; set; }

        public Guid DocumentId { get; set; }


    }
}
