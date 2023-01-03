using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class RoomDto 
    {
    
          public Guid Id { get; set; }
          public Guid BuildingId { get; set; }
          public int  RoomNumber { get; set; }
          public int  FloorNumber { get; set; }
          public int NumberOfBeds { get; set; }
          public string ClientEmail { get; set; }
          public bool isBooked { get; set; }
    }  
}
