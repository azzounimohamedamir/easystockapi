using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class Listing
    {
        public Guid ListingId { get; set; }
        public Names Names { get; set; }
        public List<ListingDetail> ListingDetails { get; set; }
        public bool WithImage { get; set; }
        public Guid HotelId { get; set; }
    }

    public class ListingDetail
    {
        public Guid Id { get; set; }
        public Names Names { get; set; }
        public string PictureUrl { get; set; }
        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
