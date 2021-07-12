using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ReservationClientDto
    {
        public Guid ReservationId { get; set; }
        public string ReservationName { get; set; }
        public int NumberOfDiners { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid FoodBusinessId { get; set; }
        public string FoodBusinessName { get; set; } 

    }
}