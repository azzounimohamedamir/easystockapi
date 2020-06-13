using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage dish currencies
    /// </summary>
    public class OrderModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int SeatId { get; set; }
        public string TableNumber { get; set; }
        public int SeatNumber { get; set; }
        public List<OrderLineModel> Lines { get; set; }
        public double Total { get; set; }
    }
}
