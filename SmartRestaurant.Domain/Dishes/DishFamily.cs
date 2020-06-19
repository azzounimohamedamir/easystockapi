using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Dishes
{
    public class DishFamily : BaseEntity<Guid>
    {
        public Guid RestaurantId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? PictureId { get; set; }
        public DishFamily Parent { get; set; }
        public Restaurant Restaurant { get; set; }
        public Picture Picture { get; set; }
        public ICollection<DishFamily> Childs { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}