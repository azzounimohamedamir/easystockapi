using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.Entities
{
    public class Dish : MenuItem
    {
        public Dish()
        {
            Supplements = new List<DishSupplement>();
            Ingredients = new List<DishIngredient>();
            Specifications = new List<DishSpecification>();
        }

        public Guid DishId { get; set; }
        public virtual IList<DishSpecification> Specifications { get; set; }
        public virtual IList<DishIngredient> Ingredients { get; set; }
        public virtual IList<DishSupplement> Supplements { get; set; }
        public bool IsSupplement { get; set; }
         public int Quantity { get; set; }
        public bool IsQuantityChecked { get; set; } 
        public int EstimatedPreparationTime { get; set; }
        public virtual IList<SectionDish> Sections { get; set; }
        public virtual IList<SubSectionDish> SubSections { get; set; }

    }
}