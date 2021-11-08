using SmartRestaurant.Domain.Enums;
using System;


namespace SmartRestaurant.Domain.Entities
{
    public class OrderDishSpecification
    {
        public Guid OrderDishSpecificationId { get; set; }
        public string Title { get; set; }
        public ContentType ContentType { get; set; }
        public bool CheckBoxContent { get; set; }
        public string ComboBoxContent { get; set; }
        public bool CheckBoxSelection { get; set; } 
        public string ComboBoxSelection { get; set; }
        public Guid OrderDishId { get; set; }
    }
}
