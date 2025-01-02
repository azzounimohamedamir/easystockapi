using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class FactureAvoir
    {

        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroAvoir { get; set; }
        public Guid IdFactureOriginal { get; set; }
        public DateTime DateAvoir { get; set; }
        public string HeureAvoir { get; set; }


        public TypeAvoir TypeAvoir { get; set; }

        public Facture OriginalFacture { get; set; }
        public List<MotifModification> MotifsAvoir { get; set; }

        public bool IsDeleted { get; set; }

        public List<RetourProductsAvoir> ProduitsRetournes { get; set; }
        public List<AjoutProductsAvoir> ProduitsAjouterAuStock { get; set; }

    }

    public class MotifModification 
    {
        public Guid Id { get; set; }
        public Guid IdAvoir { get; set; } // Identifiant de l'avoir lié à cette modification
        public FactureAvoir FactureAvoir { get; set; }

        public Motif Motif { get; set; }


        public string ModificationAt { get; set; }
        public string AncienneValeur { get; set; }

        public string NouvelleValeur { get; set; }
        public LigneFactureItems LigneFactureItem { get; set; }
    }
    public enum TypeAvoir
    {
        Suppression,
        Modification,
        Annulation,
        Remboursement,
        Correction,
        // Ajoutez d'autres types d'opérations au besoin
    }

    public enum Motif
    {
        Suppression,
        Timbre,
        Remise,
        TVA,
        RestTotal,
        LigneFacture,
        DateEcheance,
        Client
    }

    public enum LigneFactureItems
    {
        None,
        Qte,
        ProduitChange,
        PrixUnitaireVente,
        MontantHT
        
        // Add other properties as needed
    }
}
