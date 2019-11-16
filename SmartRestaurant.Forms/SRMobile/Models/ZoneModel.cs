using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage the zones of the restaurant.
    /// </summary>
    public class ZoneModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal FinancialImpact { get; set; }
        public bool FixedPrice { get; set; }
        public ICollection<TableModel> Tables { get; set; }
    }
}
