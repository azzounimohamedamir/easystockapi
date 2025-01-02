using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class AttributesWithTheirValuesDto
    {
        public string Attribute { get; set; }
        public string Value { get; set; }
    }
}
