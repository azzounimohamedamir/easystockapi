using System;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    public class Currency : AuditableEntity
    {
        public Guid CurrencyId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}