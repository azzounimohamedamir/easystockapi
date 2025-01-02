using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ProductAttributeValueDto
    {

        // Navigation properties
        public Guid Id { get; set; }

        public string AttributeValue { get; set; }
        public string AttributeName { get; set; }

    }
}
