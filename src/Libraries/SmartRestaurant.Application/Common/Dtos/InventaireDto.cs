using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class InventaireDto
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Trimestre { get; set; }
        public bool Annuel { get; set; }
        public int TotalProduitsInventaire { get; set; }
        public int TotalProduitsEnManque { get; set; }
        public int TotalProduitsEnSurnombre { get; set; }
        public List<LignesInventaireFinalDto> LignesInventaire { get; set; }
    }
}
