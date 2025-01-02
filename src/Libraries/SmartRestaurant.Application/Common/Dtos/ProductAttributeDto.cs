using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
        public class ProductAttributeDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public List<AttributeValueDto> Values { get; set; }
        }

    public class AttributeValueDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }

}
