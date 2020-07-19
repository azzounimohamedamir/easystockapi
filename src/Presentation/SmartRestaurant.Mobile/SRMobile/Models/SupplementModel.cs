namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage dish Supplements
    /// </summary>
    public class SupplementModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameFr { get; set; }
        public string NameEn { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public float Calories { get; set; }
        public float Carbo { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
    }
}
