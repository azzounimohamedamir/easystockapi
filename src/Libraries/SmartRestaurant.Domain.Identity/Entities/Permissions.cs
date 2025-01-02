using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Identity.Entities
{
    public class Permissions

    {
        public Guid Id { get; set; }

        public string Role { get; set; }
        public bool Gds { get; set; }
        public bool Stocks { get; set; }
        public bool StockAlerte { get; set; }
        public bool Unites { get; set; }
        public bool Familles { get; set; }
        public bool Marques { get; set; }
        public bool Inventaires { get; set; }
        public bool Gdv { get; set; }
        public bool Vc { get; set; }
        public bool Bl { get; set; }
        public bool Fac { get; set; }
        public bool Facpro { get; set; }
        public bool Bcv { get; set; }
        public bool RegClients { get; set; }
        public bool FacAvoir { get; set; }
        public bool RetoursProdClient { get; set; }
        public bool CreancesAss { get; set; }
        public bool Gda { get; set; }
        public bool Ba { get; set; }
        public bool Bca { get; set; }
        public bool RegFour { get; set; }
        public bool RetoursProdFour { get; set; }
        public bool Gde { get; set; }
        public bool Clients { get; set; }
        public bool Fournisseurs { get; set; }
        public bool Inviter { get; set; }

    }
}