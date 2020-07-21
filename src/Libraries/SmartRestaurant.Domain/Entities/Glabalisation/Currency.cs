using System;

namespace SmartRestaurant.Domain.Entities.Glabalisation
{
    public class Currency
    {
        public Guid CurrencyId { get; set; }
        public string Name { get; set; }
        public string Symbole { get; set; }
    }
}