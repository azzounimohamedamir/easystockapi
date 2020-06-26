using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Persistence;
using System.Collections.Generic;

namespace SmartRestaurant.Application.IntegrationTests.Helpers
{
    class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Restaurants.AddRange(GetCreateRestaurant());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Restaurants.RemoveRange(db.Restaurants);
            InitializeDbForTests(db);
        }

        public static List<Restaurant> GetCreateRestaurant()
        {
            return new List<Restaurant>()
            {

            };
        }
    }
}
