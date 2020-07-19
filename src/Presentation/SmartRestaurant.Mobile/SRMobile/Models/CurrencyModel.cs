namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage dish currencies
    /// </summary>
    public class CurrencyModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameFr { get; set; }
        public string NameEn { get; set; }
        public float ExchangeRate { get; set; }
    }
}
