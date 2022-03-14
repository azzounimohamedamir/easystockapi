using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ActiveMenuDto
    {
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public List<ActiveSectionDto> Sections { get; set; }
    }
}