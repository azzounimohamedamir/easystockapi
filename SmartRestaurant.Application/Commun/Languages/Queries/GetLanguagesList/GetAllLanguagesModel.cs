namespace SmartRestaurant.Application.Commun.Languages.Queries.GetLanguagesList
{
    public class GetAllLanguagesModel
    {

        public string Name { get; set; }
        public string IsoCode { get; set; }
        public bool IsRTL { get; set; }
        public string Alias { get; set; }
        public string Id { get; set; }
    }
}