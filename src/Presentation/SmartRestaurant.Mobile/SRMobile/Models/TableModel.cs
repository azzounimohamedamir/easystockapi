namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage tables of the restaurant.
    /// </summary>
    public class TableModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public short SeatCount { get; set; }


        /// <summary>
        /// The Id of the zone who the table belong to.
        /// </summary>
        public int? ZoneId { get; set; }
    }
}
