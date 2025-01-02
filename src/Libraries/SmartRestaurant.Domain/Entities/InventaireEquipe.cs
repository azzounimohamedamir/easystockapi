using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class InventaireEquipe 
    {
        public Guid Id { get; set; }
        public DateTime DateCreationInv { get; set; }
        public Equipe Equipe { get; set; }
        public List<LignesInventaireEquipe> Lignes { get; set; }
    }
}
