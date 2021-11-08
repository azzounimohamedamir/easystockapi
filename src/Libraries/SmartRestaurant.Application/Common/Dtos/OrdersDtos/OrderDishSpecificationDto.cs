using SmartRestaurant.Domain.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderDishSpecificationDto
    {
        public string Title { get; set; }
        public ContentType ContentType { get; set; }
        public bool CheckBoxContent { get; set; }
        public List<string> ComboBoxContent { get; set; }
        public bool CheckBoxSelection { get; set; }
        public string ComboBoxSelection { get; set; }
    }
}
