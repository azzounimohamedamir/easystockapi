using SmartRestaurant.Domain.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.DishDtos
{
    public class DishSpecificationDto
    {
        public string Title { get; set; }
        public ContentType ContentType { get; set; }
        public bool CheckBoxContent { get; set; }
        public List<string> ComboBoxContent { get; set; }
    }
}
