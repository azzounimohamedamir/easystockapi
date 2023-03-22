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
        public Guid TypeReclamationId { get; set; }
        public byte[] Picture { get; set; }
        public ReclamationStatus Status { get; set; }
        public DateTime InProgressBeginAt { get; set; }
        public DateTime DelaiExpiredAt { get; set; }
        public bool IsHidden { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
