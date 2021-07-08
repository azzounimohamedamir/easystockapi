using System;

namespace SmartRestaurant.Domain.Entities
{
    public class SubSection
    {
        public Guid SubSectionId { get; set; }
        public string Name { get; set; }
        public Guid SectionId { get; set; }
        public Section Section { get; set; }
    }
}