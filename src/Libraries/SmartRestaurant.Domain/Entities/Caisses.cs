using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Caisses
    {
        public string Id { get; set; }
        public int? Numero { get; set; }
        public bool? Status { get; set; }
        public string Vendeur { get; set; }
        public Guid UserId { get; set; }

        public decimal? SoldeJ { get; set; }
        public decimal? SoldeM { get; set; }
    }
}
