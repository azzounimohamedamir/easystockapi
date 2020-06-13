using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Enumerations
{
    public enum EnumState
    {
        Waitting=1,
        InProgress=2,
        Ready=3,
        Delivred=4,
        Paid=5,
        Free=6,
        Canceled=7,
    }
}
