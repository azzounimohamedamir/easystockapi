using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class FacProProductsDto
    {
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
        public Guid SelectedStockId { get; set; }
        [ForeignKey("SelectedStockId")]
        public StockDto SelectedStock { get; set; }

    }
}