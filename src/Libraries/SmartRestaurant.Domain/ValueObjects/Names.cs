using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class Names : ValueObject
    {
        public string AR { get; set; }
        public string EN { get; set; }
        public string FR { get; set; }
        public string TR { get; set; }
        public string RU { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                AR,
                EN,
                FR,
                TR, 
                RU
            };
        }
    }
}
