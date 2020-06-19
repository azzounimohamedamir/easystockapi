using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Dishes
{
    public class DishEquivalence : SmartRestaurantEntity
    {
        public Guid ParentId { get; set; }
        public Dish Parent { get; set; }

        public Guid EquivalenceId { get; set; }
        public Dish Equivalence { get; set; }

        public Quantity QuantityParent { get; set; }
        public Quantity QuantityEquivalence { get; set; }
    }
}