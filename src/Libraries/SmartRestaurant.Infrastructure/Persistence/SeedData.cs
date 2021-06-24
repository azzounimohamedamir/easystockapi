using System;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodBusiness>().HasData(
                new FoodBusiness
                {
                    FoodBusinessId = Guid.Parse("3cbf3570-4444-4673-8746-29b7cf568093"),
                    Name = "Taj mahal",
                    AcceptsCreditCards = true,
                    AcceptTakeout = true,
                    AverageRating = 4,
                    Description = "",
                    HasCarParking = true,
                    IsHandicapFriendly = true,
                    OffersTakeout = true,
                    Tags = "",
                    Website = "",
                    FoodBusinessAdministratorId = "3cbf3570-4444-4444-8746-29b7cf568093",
                    FoodBusinessCategory = FoodBusinessCategory.Restaurant
                }
            );
        }
    }
}