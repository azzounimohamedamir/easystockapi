using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ActiveSectionDto
    {
        public Guid SectionId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> HasSubSection { get; set; }
        public List<ActiveSubSectionDto> SubSections { get; set; }
        public ActiveMenuItemDto MenuItems { get; set; }
    }
}