using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    // entity hotel
    public class Building: AuditableEntity
    {
      
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public Guid? HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }

    
}
