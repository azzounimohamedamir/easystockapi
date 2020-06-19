using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Allergies
{
    public class Allergy : BaseEntity<Guid>
    {
        public Allergy()
        {
            FoodAllergies = new List<FoodAllergy>();
        }
        public ICollection<FoodAllergy> FoodAllergies { get; set; }
    }
}
