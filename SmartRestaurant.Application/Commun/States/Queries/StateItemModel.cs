using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.States.Queries
{
    public class StateItemModel
    {
        public string Id { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }
        public string CountryName { get; set; }
        public string CountryIsoCode { get; set; }
        public string IsDisabled { get; set; }
    }
}
