using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Reclamation
    {
        public Guid Id { get; set; }
        public Guid CheckinId { get; set; }
        public Guid ClientId { get; set; } 
        public Guid RoomId { get; set; }
        
        public Names ReclamationDescription { get; set; }
        public byte[] Picture { get; set; }
        public ReclamationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
