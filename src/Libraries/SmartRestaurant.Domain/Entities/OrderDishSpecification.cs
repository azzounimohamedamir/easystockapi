using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderDishSpecification
    {
        public Guid OrderDishSpecificationId { get; set; }
        public string Title { get; set; }
        public Names Names { get; set; }
        public ContentType ContentType { get; set; }
        public bool CheckBoxContent { get; set; }
        public string ComboBoxContent { get; set; }
        public List<OrderComboBoxItemTranslation> ComboBoxContentTranslation { get; set; }
        public bool CheckBoxSelection { get; set; } 
        public string ComboBoxSelection { get; set; }
        public Guid OrderDishId { get; set; }
    }
}
