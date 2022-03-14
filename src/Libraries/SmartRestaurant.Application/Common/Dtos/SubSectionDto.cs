using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class SubSectionDto
    {
        public Guid SubSectionId { get; set; }
        public string Name { get; set; }
        public Guid SectionId { get; set; }
    }
}