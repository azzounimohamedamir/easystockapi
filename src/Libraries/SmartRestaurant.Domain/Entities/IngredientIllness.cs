using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class IngredientIllness
    {
        public Guid IllnessId { get; set; }
        public Illness Illness { get; set; }
        public float Quantity { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
