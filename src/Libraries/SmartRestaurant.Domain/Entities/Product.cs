using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class Product : MenuItem
    {
        public Guid ProductId { get; set; }
        public virtual IList<SectionProduct> Sections { get; set; }
    }


}
