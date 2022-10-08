using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    // entity hotel
    public class Hotel: Entreprise
    {
      
            public Guid Id { get; set; }
            public string ImagUrl { get; set; }
            public byte[] Picture { get; set; }

            public string FoodBusinessAdministratorId { get; set; }
        }

    
}
