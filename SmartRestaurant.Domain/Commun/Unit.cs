using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class Unit:BaseEntity<Guid>
    {
        //gr, kg, cl, 
        public string Symbol { get; set; }
    }
}
