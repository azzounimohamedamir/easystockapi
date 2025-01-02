using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Inventaire
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Trimestre { get; set; }
        public bool Annuel { get; set; }
        public int TotalProduitsInventaire { get; set; }
        public int TotalProduitsEnManque { get; set; }
        public int TotalProduitsEnSurnombre { get; set; }
        public List<LignesInventaireFinal> LignesInventaire { get; set; }
    }
}
