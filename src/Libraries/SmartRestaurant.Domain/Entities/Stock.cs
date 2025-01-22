using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Stock
    {
        
        public Guid Id { get; set; }
        public string CodeP{ get; set; }

        public string Designaation { get; set; }
        public string Image { get; set; }

        public string CodeBar { get; set; }

       
       

        public string Rayonnage { get; set; }

        public decimal QteAlerte { get; set; }
        public decimal QteInitiale { get; set; }

        public decimal QteRestante { get; set; }
        public decimal PrixVenteDetail { get; set; }
        public decimal PrixAchat { get; set; }

        public decimal PrixVenteGros { get; set; }
        public decimal Tva { get; set; }
        public bool IsPerissable { get; set; }
        public DateTime DatePeremption { get; set; }
        public int JourAlerte { get; set; }
        public bool IsFavoris {  get; set; }

        // Navigation property
        public string ProductAttributeValues { get; set; }


    }
}
