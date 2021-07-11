using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ReservationDto
    {
        public Guid ReservationId { get; set; }
        public string ReservationName { get; set; }
        public int NumberOfDiners { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}