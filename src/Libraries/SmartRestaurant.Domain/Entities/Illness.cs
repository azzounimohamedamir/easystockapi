using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Illness
    {
        public Guid IllnessId { get; set; }
        public string Name { get; set; }
        public Names Names { get; set; }
        public IList<IngredientIllness> IngredientIllnesses { get; set; }
    }
}
