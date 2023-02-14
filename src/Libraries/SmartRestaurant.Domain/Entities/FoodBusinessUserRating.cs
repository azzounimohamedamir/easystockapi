using System;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class FoodBusinessUserRating
    {
        public Guid FoodBusinessId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public int Rating { get; set; }

    }
}