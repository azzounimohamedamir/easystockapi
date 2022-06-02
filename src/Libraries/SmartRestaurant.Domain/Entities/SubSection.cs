using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class SubSection
    {
        public SubSection()
        {
            Dishes = new List<SubSectionDish>();
            Products = new List<SubSectionProduct>();
        }

        public Guid SubSectionId { get; set; }
        public string Name { get; set; }
        public Names Names { get; set; }
        public Guid SectionId { get; set; }
        public Section Section { get; set; }
        public virtual IList<SubSectionDish> Dishes { get; set; }
        public virtual IList<SubSectionProduct> Products { get; set; }
    }
}