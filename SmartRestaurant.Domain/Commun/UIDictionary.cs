namespace SmartRestaurant.Domain.Commun
{
    /// <summary>
    /// UI MenuTitle
    /// fr-FR
    /// Titre du menu
    /// UI Confirmation added message
    /// fr-FR
    /// Félicitation! votre demande est bien enregistré sur le systeme.
    /// </summary>
    public class UIDictionary : SmartRestaurantEntity
    {
        public string LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Language Language { get; set; }
    }
}
