using System;

namespace SmartRestaurant.Domain.Entities
{
    public class FoodBusinessUser
    {
        public string ApplicationUserId { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
    }
}
