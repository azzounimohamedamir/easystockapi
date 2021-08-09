using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
   public class LinkedDeviceDto
    {
        //public Guid DeviceIDId { get; set; }
        public string IdentifierDevice { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}
