namespace SmartRestaurant.Domain.Commun
{
    public class City : SmartRestaurantBaseEntity<string>
    {
        public string StateId { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public virtual State State { get; set; }
    }
}