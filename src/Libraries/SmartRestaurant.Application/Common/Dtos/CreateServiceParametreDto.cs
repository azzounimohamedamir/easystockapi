using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CreateServiceParametreDto:CreateCommand
    {
        public Names Names { get; set; }
        public bool IsShowing { get; set; }
        public bool IsRequired { get; set; }
        public ServiceParametreType ServiceParametreType { get; set; }
        public string ListingId { get; set; }
        public bool WithImage { get; set; }

        public string HotelServiceId { get; set; }
    }
}
