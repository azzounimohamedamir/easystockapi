using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ReclamationDto
    {
        public Guid Id { get; set; }
        public Guid TypeReclamationId { get; set; }
        public string HotelName { get; set; }
        public string HotelId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public string BuildingName { get; set; }
        public int RoomNumber { get; set; }
        public int  FloorNumber { get; set; }
        public ReclamationStatus Status { get; set; }
        public Names ServiceTechniqueOfReclamation { get; set; }

        public Names ReclamationDescription { get; set; }

        public Guid ServiceTechniqueId { get; set; }
        public byte[] Picture { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime DelaiFinishedAt { get; set; }
        public bool IsHidden { get; set; }
    }
}
