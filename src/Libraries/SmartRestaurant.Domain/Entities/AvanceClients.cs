using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class AvanceClients
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public decimal MontantAvance { get; set; }
        public DateTime DateAvance { get; set; }
        public Client Client { get; set; }


    }
}
