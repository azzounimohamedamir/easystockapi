namespace SmartRestaurant.Application.Commun.Languages.Queries
{
    public class LanguageItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public bool IsRTL { get; set; }
        public string Alias { get; set; }
        public string SelectLanguage { get; set; }
        public string IsDisabled { get; set; }

        public string EnglishName { get; set; }
    }
}
