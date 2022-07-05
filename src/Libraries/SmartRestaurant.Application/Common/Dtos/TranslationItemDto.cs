using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class TranslationItemDto
    {
        public string Name { get; set; }
        public NamesDto Names { get; set; }
    }
}
