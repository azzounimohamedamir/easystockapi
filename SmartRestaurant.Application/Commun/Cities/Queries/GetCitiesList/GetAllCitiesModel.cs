namespace SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesList
{
    public class GetAllCitiesModel
    {
        public string Id { get; set; }
        public string StateId { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }
        public string StateName { get; set; }
        public string StateIsoCode { get; set; }
        //public string CountryName { get; set; }
        //public string CountryCode { get; set; }
    }
}