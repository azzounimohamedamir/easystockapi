using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Currencies.Queries
{
    public class CurrencyItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }
        public bool IsSelected { get; set; }
        public string IsDisabled { get; set; }

    }
}
