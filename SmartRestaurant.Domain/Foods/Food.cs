using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartRestaurant.Domain.Dishes;

namespace SmartRestaurant.Domain.Foods
{
    public class Food:BaseEntity<Guid>
    {        
        public Guid FoodCategoryId { get; set; }
        public Guid? PictureId { get; set; }
        public Guid? UnitId { get; set; }
        public Unit Unit { get; set; }
        public Picture Picture { get; set; }
        public FoodCategory Category { get; set; }
        public Nutrition Nutrition { get; set; }
        public bool IsNatural { get; set; }
        public bool IsIndustriel { get; set; }

        public ICollection<FoodComposition> Compositions { get; set; }
        public ICollection<FoodAllergy> FoodAllergies { get; set; }
        public ICollection<FoodIllness> FoodIllnesses { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
