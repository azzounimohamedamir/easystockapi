using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class TranslationItem
    {
        public string Name { get; set; }
        public Names Names { get; set; }
    }
}
