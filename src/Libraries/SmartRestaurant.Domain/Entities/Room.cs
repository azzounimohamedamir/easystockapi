using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Room 
    {
          public Guid Id { get; set; }
          public Guid BuildingId { get; set; }
          public Guid ClientId { get; set; }
          public int  RoomNumber { get; set; }
          public int  FloorNumber { get; set; }
          public int NumberOfBeds { get; set; }
          public string ClientEmail { get; set; }
          public bool IsBooked { get; set; }
    }  
}
