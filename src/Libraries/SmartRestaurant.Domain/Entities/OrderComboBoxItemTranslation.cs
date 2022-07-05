using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderComboBoxItemTranslation :TranslationItem
    {
        public Guid OrderComboBoxItemTranslationId { get; set; }
        public Guid OrderDishSpecificationId { get; set; }
    }
}
