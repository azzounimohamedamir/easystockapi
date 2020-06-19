using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Foods;
using System;

namespace SmartRestaurant.Domain.Allergies
{
    public class FoodIllness : SmartRestaurantBaseEntity<Guid>
    {
        public Guid FoodId { get; set; }
        public Guid IllnessId { get; set; }
        public Illness Illness { get; set; }
        public Food Food { get; set; }
    }
}
