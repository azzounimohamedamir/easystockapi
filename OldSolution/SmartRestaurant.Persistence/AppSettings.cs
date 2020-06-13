using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence
{
    public class AppSettings
    {
        public string SmartRestaurantSqlConnection { get; set; }
        public string SmartRestaurantIdentityDbContext { get; set; }
    }
}
