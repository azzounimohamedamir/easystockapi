﻿using System;

namespace SmartRestaurant.Domain.Entities
{
    public class NiveauFidelite
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public int MaxPointsRequis { get; set; } // Nombre de points requis pour atteindre ce niveau de fidélité

        public decimal Remise { get; set; } // Remise applicable pour ce niveau de fidélité (en pourcentage)
    }
}
