using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ActiveSubSectionDto
    {
        public Guid SubSectionId { get; set; }
        public string Name { get; set; }
        public ActiveMenuItemDto MenuItems { get; set; }
    }
}