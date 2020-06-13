using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Dishes
{
    public class Dish:BaseEntity<Guid>
    {
        public Guid RestaurantId { get; set; }
        public EnumDishType Type { get; set; }
        public Guid FamillyId { get; set; }
        public Guid? GalleryId { get; set; } 
        public Time PreparationTime { get; set; }        
        public Time ServiceTime { get; set; }
        public Time Total { get; } //=> PreparationTime + ServiceTime;
        public DishFamily Family { get; set; }
        public Gallery Gallery { get; set; }

        public Guid? MenuItemId { get; set; }

        public ICollection<DishIngredient> Ingredients { get; set; }

        public ICollection<DishAccompanying> ParentAccompaniments { get; set; }
        public ICollection<DishAccompanying> ChildAccompaniments { get; set; }

        public ICollection<DishEquivalence> ParentEquivalences { get; set; }
        public ICollection<DishEquivalence> ChildEquivalences { get; set; }
        public Restaurant Restaurant { get; set; }
        public MenuItem MenuItem { get; set; }

        public bool CanBeAccompanying { get; set; }

        public Pricing Pricing { get; set; }
    }
}
