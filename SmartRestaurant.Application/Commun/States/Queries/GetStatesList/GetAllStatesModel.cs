namespace SmartRestaurant.Application.Commun.States.Queries.GetStatesList
{
    public class UpdateStateModel
    {


        public string Id { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }

        public string CountryName { get; set; }
        public string CountryIsoCode { get; set; }
    }
}