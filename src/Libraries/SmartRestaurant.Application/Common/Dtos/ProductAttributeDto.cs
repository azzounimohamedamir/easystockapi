using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ProductAttributeDto
    {
        public string Nom { get; set; }
        public List<AttributeValueDto> AttributeValues { get; set; }
    }

    public class AttributeValueDto
    {
        public string Valeur { get; set; }
    }

}
