using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Section
    {
        public Guid SectionId { get; set; }
        public string Name { get; set; }
        public Guid? RootSectionId { get; set; }
        public Section RootSection { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}