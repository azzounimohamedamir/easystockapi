using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Interfaces
{
    public interface IPagination
    {
        int Skip { get; set; }
        int Take { get; set; }
    }
}
