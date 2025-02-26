using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class FactureAvoirDto
    {
        public Guid Id { get; set; }

        public int NumeroAvoir { get; set; }
        public Guid IdFactureOriginal { get; set; }
        public DateTime DateAvoir { get; set; }
        public string HeureAvoir { get; set; }


        public TypeAvoir TypeAvoir { get; set; }

        public FactureDto OriginalFacture { get; set; }
        public List<MotifModificationDto> MotifsAvoir { get; set; }

        public bool IsDeleted { get; set; }

        public List<RetourProductsAvoirDto> ProduitsRetournes { get; set; }
        public List<AjoutProductsAvoirDto> ProduitsAjouterAuStock { get; set; }
    }

    public class MotifModificationDto
    {
        public Guid Id { get; set; }
        public Guid IdAvoir { get; set; } // Identifiant de l'avoir lié à cette modification

        public Motif Motif { get; set; }


        public string ModificationAt { get; set; }
        public string AncienneValeur { get; set; }

        public string NouvelleValeur { get; set; }
        public LigneFactureItems LigneFactureItem { get; set; }
    }
}
