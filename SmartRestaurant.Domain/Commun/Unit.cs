using System;

namespace SmartRestaurant.Domain.Commun
{
    public class Unit : BaseEntity<Guid>
    {
        //gr, kg, cl, 
        public string Symbol { get; set; }
    }
}
