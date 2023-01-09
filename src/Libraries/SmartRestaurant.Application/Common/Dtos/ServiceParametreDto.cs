using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ServiceParametreDto
    {
        public Guid Id { get; set; }
        public Names Names { get; set; }
        public bool IsShowing { get; set; }
        public bool IsRequired { get; set; }
        public ServiceParametreType ServiceParametreType { get; set; }
        public Guid ListingId { get; set; }
        public List<ListingDetailDto> Details { get; set; }
        public bool WithImage { get; set; }
    }
}
