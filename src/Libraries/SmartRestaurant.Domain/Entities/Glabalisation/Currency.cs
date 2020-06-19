using System;

namespace SmartRestaurant.Domain.Entities.Glabalisation
{
    public class Currency
    {
        public Guid CurrencyId { get; protected set; }
        public string Name { get; protected set; }
        public string Symbole { get; protected set; }
    }
}