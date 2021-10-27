using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class SectionDto
    {
        public Guid SectionId { get; set; }
        public string Name { get; set; }
        public Guid MenuId { get; set; }
        public Nullable<bool> HasSubSection { get; set; }
    }
}