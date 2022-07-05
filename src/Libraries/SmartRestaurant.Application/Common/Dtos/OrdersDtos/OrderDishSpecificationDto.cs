using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderDishSpecificationDto
    {
        public string Title { get; set; }
        public NamesDto Names { get; set; }
        public ContentType ContentType { get; set; }
        public bool CheckBoxContent { get; set; }
        public List<string> ComboBoxContent { get; set; }
        public bool CheckBoxSelection { get; set; }
        public string ComboBoxSelection { get; set; }
        public List<TranslationItemDto> ComboBoxContentTranslation { get; set; }
    }
}
