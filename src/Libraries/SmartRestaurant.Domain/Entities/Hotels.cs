using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Hotels
    {
      
            public Guid Id { get; set; }
            public string ImagUrl { get; set; }
            public string FoodBusinessAdministratorId { get; set; }
            public string Name { get; set; }
        }

    
}
