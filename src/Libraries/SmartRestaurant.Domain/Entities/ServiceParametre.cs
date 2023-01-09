using SmartRestaurant.Domain.ValueObjects;
using System;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class ServiceParametre
    {
        public Guid Id { get; set; }
        public Names Names { get; set; }
        public bool IsShowing { get; set; }
        public bool IsRequired { get; set; }
        public ServiceParametreType ServiceParametreType { get; set; }
        public Guid ListingId { get; set; }
        public Guid HotelServiceId { get; set; }
        public HotelService HotelService { get; set; }
    }

   
}
