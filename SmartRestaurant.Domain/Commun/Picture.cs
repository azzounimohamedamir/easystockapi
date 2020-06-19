using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Restaurants;
using System;

namespace SmartRestaurant.Domain.Commun
{
    public class Picture : BaseEntity<Guid>
    {
        public Guid? RestaurantId { get; set; }
        public Guid? GalleryId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual Gallery Gallery { get; set; }
        public virtual Food Food { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
    }
}