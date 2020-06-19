
namespace SmartRestaurant.Domain.Commun
{
    public class Language : SmartRestaurantBaseEntity<string>
    {
        public string Name { get; set; }
        public string SelectLanguage { get; set; }
        public string IsoCode { get; set; }
        public bool IsRTL { get; set; }
        public string EnglishName { get; set; }
    }
}
