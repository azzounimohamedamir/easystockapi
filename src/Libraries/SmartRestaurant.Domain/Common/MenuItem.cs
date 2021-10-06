using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Domain.Common
{
    public class MenuItem : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public Guid? SubSectionId { get; set; }
        public Guid? SectionId { get; set; }
        public virtual SubSection SubSection { get; set; }
        public virtual Section Section { get; set; }
    }
}
