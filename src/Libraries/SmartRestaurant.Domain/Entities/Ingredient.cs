using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class Ingredient : AuditableEntity
    {
        public Guid IngredientId { get; set; }
        public string Names { get; set; }
        public byte[] Picture { get; set; }
        public EnergeticValue EnergeticValue { get; set; }
        public virtual IList<DishIngredient> Dishes { get; set; }
    }
}