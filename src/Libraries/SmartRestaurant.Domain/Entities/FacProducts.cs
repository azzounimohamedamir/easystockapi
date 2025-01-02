using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class FacProducts
    {
        [Key]
        public Guid Id { get; set; }
        public string Image { get; set; }

        public string Designation { get; set; }
        public decimal Qte { get; set; }
        public decimal MontantHT { get; set; }
        public decimal MontantTVA { get; set; }
        public decimal MontantTTC { get; set; }

        public decimal Puv { get; set; }
        public decimal LastPuv { get; set; }
        public bool HasReduction { get; set; }
        public float Reduction { get; set; }
        public Facture Facture { get; set; }

        public Guid FactureId { get; set; }
        public Guid SelectedStockId { get; set; }
        public Stock SelectedStock { get; set; }
    }
}
