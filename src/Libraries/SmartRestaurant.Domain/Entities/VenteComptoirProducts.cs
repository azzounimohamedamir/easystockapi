using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class VenteComptoirProducts
    {
        [Key]
        public Guid Id { get; set; }
        public string Image { get; set; }

        public string Designation { get; set; }
        public decimal Qte { get; set; }
        public decimal Puv { get; set; }
        public decimal LastPuv { get; set; }
        public bool HasReduction { get; set; }
        public float Reduction { get; set; }
        public decimal Montant { get; set; }


        public Guid VenteComptoirId { get; set; }
        public Guid SelectedStockId { get; set; }
        [ForeignKey("SelectedStockId")]
        public Stock SelectedStock { get; set; }


    }
}
