using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class StockDto
    {
        public Guid Id { get; set; }
        public string Designaation { get; set; }
        public string Image { get; set; }

        public string CodeBar { get; set; }

      
        public string Rayonnage { get; set; }

        public int QteAlerte { get; set; }
        public int QteInitiale { get; set; }

        public int QteRestante { get; set; }
        public decimal PrixVenteDetail { get; set; }
        public decimal PrixAchat { get; set; }

        public decimal PrixVenteGros { get; set; }
        public decimal Tva { get; set; }
        public bool IsPerissable { get; set; }
        public DateTime DatePeremption { get; set; } = DateTime.Now;
        public int JourAlerte { get; set; }
        public bool PrintingBarcode { get; set; } = false;
        public int QuantityToPrint { get; set; } = 1;
        public string ProductAttributeValues { get; set; }
    }
}
