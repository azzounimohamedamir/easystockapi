using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.DateTime
{
    public class MachineDateTime : IDateTime
    {
        public System.DateTime Now => System.DateTime.Now;
    }
}
