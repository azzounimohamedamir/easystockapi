using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class SubSectionDto
    {
        public Guid SubSectionId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public NamesDto Names { get; set; }
        public Guid SectionId { get; set; }
    }
}