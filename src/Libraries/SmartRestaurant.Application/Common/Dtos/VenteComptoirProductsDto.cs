using System;

namespace SmartRestaurant.Application.Common.Dto
{
    public class VenteComptoirProductsDto
    {

        public Guid ProductId { get; set; }
        public string Designation { get; set; }
        public decimal Qte { get; set; }
        public decimal Puv { get; set; }
        public decimal Montant { get; set; }
        public Guid VenteComptoirId { get; set; }


    }
}
