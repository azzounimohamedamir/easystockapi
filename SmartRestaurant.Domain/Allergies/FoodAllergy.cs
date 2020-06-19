using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Foods;
using System;

namespace SmartRestaurant.Domain.Allergies
{
    public class FoodAllergy : SmartRestaurantBaseEntity<Guid>
    {
        public Guid FoodId { get; set; }
        public Guid AllergyId { get; set; }
        public Allergy Allergy { get; set; }
        public Food Food { get; set; }
    }
}
