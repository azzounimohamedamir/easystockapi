using SmartRestaurant.Domain.Enums;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class DishSpecification
    {
        public Guid DishSpecificationId { get; set; }
        public string Title { get; set; }
        public ContentType ContentType { get; set; }
        public bool CheckBoxContent { get; set; }
        public string ComboBoxContent { get; set; }
        public Guid DishId { get; set; }
    }
}
