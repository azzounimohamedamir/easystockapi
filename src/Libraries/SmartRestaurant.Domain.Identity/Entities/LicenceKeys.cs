using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Identity.Entities
{
    public class LicenceKeys
    {
        public Guid Id { get; set; }
        public string LicenceKey { get; set; }
        public Guid ClientId { get; set; }

        public string ClientName { get; set; }
        public bool Status { get; set; }
        public DateTime ExpDate { get; set; }

    }
}
