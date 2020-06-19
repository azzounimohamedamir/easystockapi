using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Allergies
{
    public class Illness : BaseEntity<Guid>
    {
        public Illness()
        {
            FoodIllnesses = new List<FoodIllness>();
        }
        public ICollection<FoodIllness> FoodIllnesses { get; set; }
    }
}
