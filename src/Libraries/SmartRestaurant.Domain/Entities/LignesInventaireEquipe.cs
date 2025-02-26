using SmartRestaurant.Domain.Enums;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class LignesInventaireEquipe
    {
        public Guid Id { get; set; }

        public string CodeProduit { get; set; }
        public string NomProduit { get; set; }
        public string Rayonnage { get; set; }
        public string CodeBar { get; set; }
        public int? QuantiteTrouvee { get; set; }
        public Equipe? Equipe { get; set; }
    }
}
