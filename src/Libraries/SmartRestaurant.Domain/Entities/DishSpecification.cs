using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class DishSpecification
    {
        public Guid DishSpecificationId { get; set; }
        public string Title { get; set; }
        public Names Names { get; set; }
        public ContentType ContentType { get; set; }
        public bool CheckBoxContent { get; set; }
        public string ComboBoxContent { get; set; }
        public List<DishComboBoxItemTranslation> ComboBoxContentTranslation { get; set; }
        public Guid DishId { get; set; }
    }
}
