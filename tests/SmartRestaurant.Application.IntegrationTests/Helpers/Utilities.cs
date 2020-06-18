using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

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
                new Restaurant(){ NameArabic="Test 1" },
                new Restaurant(){ NameArabic="Test 2" },
                new Restaurant(){ NameArabic="Test 3"  }
            };
        }
    }
}
