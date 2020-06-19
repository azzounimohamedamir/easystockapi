using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    //Caractéristiques du restaurant
    //Accepte les cartes bancaires
    //Accès personnes handicapées
    //Parking
    //Plats à emporter
    //Réservations
    //Salle privée
    //Service de livraison
    //Service de table
    //Télévision
    //Terrasse
    //Wi-Fi gratuit
    public class RestaurantFeature
    {
        public Guid RestaurantId { get; set; }
        public Guid FeatureId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Feature Feature { get; set; }
    }
}