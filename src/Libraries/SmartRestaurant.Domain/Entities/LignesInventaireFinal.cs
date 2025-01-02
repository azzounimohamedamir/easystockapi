using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class LignesInventaireFinal
    {
        public Guid Id { get; set; }
        public string CodeProduit { get; set; }
        public string NomProduit { get; set; }
        public string Rayonnage { get; set; }

        public string CodeBar { get; set; }
        public decimal QuantiteTrouveeA { get; set; }
        public decimal QuantiteTrouveeB { get; set; }
        public decimal QuantiteTrouveeReel { get; set; }
        public decimal QuantiteStockLogiciel { get; set; }
        public decimal QteEcart { get; set; }
        public bool Manque { get; set; }
        public bool Surnombre { get; set; }
        public bool Egaux { get; set; }
        public string Observation { get; set; }
    }
}
