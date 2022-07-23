using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class DishComboBoxItemTranslation : TranslationItem
    {
        public Guid DishComboBoxItemTranslationId { get; set; }

        public Guid DishSpecificationId { get; set; }
    }
}
