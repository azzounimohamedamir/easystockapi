using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public string ClientName { get; set; }
        public int NumberOfDiners { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
    }
}