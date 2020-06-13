using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class Gallery:BaseEntity<Guid>
    {
        public Guid? RestaurantId { get; set; }
        public Guid? DishId { get; set; }
        public Guid? MenuItemId { get; set; }
        //if null then First()
        public string TheCoverPictureId { get; set; }
        public ICollection<Picture> Pictures { get; set; }        
        public Restaurant Restaurant { get; set; }
        public Dish Dish { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
