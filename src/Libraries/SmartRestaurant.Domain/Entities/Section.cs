using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class Section
    {
        public Section()
        {
            Dishes = new List<SectionDish>();
            Products = new List<SectionProduct>();
        }

        public Guid SectionId { get; set; }
        public string Name { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
        public Nullable<bool> HasSubSection { get; set; }
        public virtual IList<SectionDish> Dishes { get; set; }
        public virtual IList<SectionProduct> Products { get; set; }
    }
}