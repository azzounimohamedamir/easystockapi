using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class Product : MenuItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsQuantityChecked { get; set; } 
        public virtual IList<SectionProduct> Sections { get; set; }
        public virtual IList<SubSectionProduct> SubSections { get; set; }

    }


}
