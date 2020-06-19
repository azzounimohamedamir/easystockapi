using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Seed
{
    internal static class FoodsSeed
    {
        internal  static void SeedFoods(SmartRestaurantDbContext context)
        {

             context.SaveChangesAsync();
        }

        
    }
}
