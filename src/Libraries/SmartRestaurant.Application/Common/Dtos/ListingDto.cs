using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ListingDto
    {
        public Guid ListingId { get; set; }
        public Names Names { get; set; }
        public List<ListingDetailDto> ListingDetails { get; set; } 
        public bool WithImage { get; set; }
    }
}

public class ListingDetailDto
{
    public Guid Id { get; set; }
    public Names Names { get; set; }
    public string Picture { get; set; }
}