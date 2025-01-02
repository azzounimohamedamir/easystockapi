using SmartRestaurant.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class SocieteInfo
    {
        public Guid Id { get; set; }
        public string NomSociete { get; set; }
        public string Activite { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Siteweb { get; set; }
        public string Adresse { get; set; }
        public string RegistreCommerce { get; set; }
        public string Rib { get; set; }
        public string Nif { get; set; }
        public string Nis { get; set; }
        public string NumeroArticle { get; set; }
        public string Logo { get; set; } // Assuming the logo is stored as a URL in the backend

    }
}
