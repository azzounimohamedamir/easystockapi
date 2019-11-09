using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage tables of the restaurant.
    /// </summary>
    public class TableModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public short NombreChaises { get; set; }


        /// <summary>
        /// The Id of the zone who the table belong to.
        /// </summary>
        public int? ZoneId { get; set; }
    }
}
