using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class NiveauFideliteDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public int MinPointsRequis { get; set; } // Nombre de points requis pour atteindre ce niveau de fidélité
        public int MaxPointsRequis { get; set; } // Nombre de points requis pour atteindre ce niveau de fidélité
        public decimal Remise { get; set; } // Remise applicable pour ce niveau de fidélité (en pourcentage)
    }
}
