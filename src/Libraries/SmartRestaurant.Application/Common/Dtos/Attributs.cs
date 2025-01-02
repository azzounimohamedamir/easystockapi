using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class Attributs
    {
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int QteInitiale { get; set; }
        public string Image { get; set; }
        public string ImagePreview { get; set; } // Optional property to store image preview
    }
}
