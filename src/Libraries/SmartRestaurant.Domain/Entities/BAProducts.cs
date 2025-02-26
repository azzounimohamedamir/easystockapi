using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRestaurant.Domain.Entities
{
    public class BAProducts
    {
        [Key]
        public Guid Id { get; set; }
        public string Image { get; set; }

        public string Designation { get; set; }
        public decimal Qte { get; set; }
        public decimal MontantHT { get; set; }
        public decimal MontantTVA { get; set; }
        public decimal MontantTTC { get; set; }

        public decimal Pua { get; set; }
        public decimal Pmp { get; set; }
        public decimal Newpua { get; set; }


        public Guid BAId { get; set; }
        public Guid SelectedStockId { get; set; }
        [ForeignKey("SelectedStockId")]
        public Stock SelectedStock { get; set; }
    }
}
