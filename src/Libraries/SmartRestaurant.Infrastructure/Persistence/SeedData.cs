using System;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Infrastructure.Persistence
{
    public static class SeedData
    {
        public const string TajMhal_FoodBusinessId = "3cbf3570-4444-4673-8746-29b7cf568093";
        public const string Mcdonald_FoodBusinessId = "66bf3570-440d-4673-8746-29b7cf568099";

        public const string TajMhal_FoodBusinessAdministrator_UserId = "3cbf3570-4444-4444-8746-29b7cf568093";
        public const string Mcdonald_FoodBusinessAdministrator_UserId = "44bf3570-0d44-4673-8746-29b7cf568088";

        public const string TajMhal_FoodBusinessManager_UserId = "a1997466-cedc-4850-b18d-0ac4f4102cff";
        public const string Mcdonald_FoodBusinessManager_UserId = "b2207466-ceda-4b50-b18d-0ac4f4102caa";

        public const string Diner_UserId_01 = "5a84cd00-59f0-4b22-bfce-07c080829118";
        public const string Diner_UserId_02 = "6b14cd00-59f0-4422-bfce-07c080829987";

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Create a FoodBusiness

            modelBuilder.Entity<FoodBusiness>().HasData(

                #region Create a FoodBusiness for TajMhal restaurant

                new FoodBusiness
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
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
                    FoodBusinessAdministratorId = TajMhal_FoodBusinessAdministrator_UserId,
                    FoodBusinessCategory = FoodBusinessCategory.Restaurant
                },

                #endregion

                #region Create a FoodBusiness for Mcdonald's restaurant

                new FoodBusiness
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    Name = "Mcdonald's",
                    AcceptsCreditCards = true,
                    AcceptTakeout = true,
                    AverageRating = 4,
                    Description = "",
                    HasCarParking = true,
                    IsHandicapFriendly = true,
                    OffersTakeout = true,
                    Tags = "",
                    Website = "",
                    FoodBusinessAdministratorId = Mcdonald_FoodBusinessAdministrator_UserId,
                    FoodBusinessCategory = FoodBusinessCategory.Restaurant
                }

                #endregion

            );

            #endregion


            #region Create reservations

            modelBuilder.Entity<Reservation>().HasData(

            #region Create reservations for user Diner_01
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596300"),
                   ReservationName = "ReservationName_00",
                   NumberOfDiners = 2,
                   ReservationDate = DateTime.Now.AddHours(5),
                   CreatedBy = SeedData.Diner_UserId_01,
                   CreatedAt = DateTime.Now
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596301"),
                   ReservationName = "ReservationName_01",
                   NumberOfDiners = 5,
                   ReservationDate = DateTime.Now.AddHours(8),
                   CreatedBy = SeedData.Diner_UserId_01,
                   CreatedAt = DateTime.Now.AddHours(5)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596302"),
                   ReservationName = "ReservationName_02",
                   NumberOfDiners = 3,
                   ReservationDate = DateTime.Now.AddDays(1),
                   CreatedBy = SeedData.Diner_UserId_01,
                   CreatedAt = DateTime.Now.AddDays(-15)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596303"),
                    ReservationName = "ReservationName_03",
                    NumberOfDiners = 2,
                    ReservationDate = DateTime.Now.AddYears(5),
                    CreatedBy = SeedData.Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddDays(15)
                },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596304"),
                   ReservationName = "ReservationName_04",
                   NumberOfDiners = 8,
                   ReservationDate = DateTime.Now.AddYears(15),
                   CreatedBy = SeedData.Diner_UserId_01,
                   CreatedAt = DateTime.Now.AddMinutes(36)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596305"),
                   ReservationName = "ReservationName_05",
                   NumberOfDiners = 13,
                   ReservationDate = DateTime.Now.AddHours(-3),
                   CreatedBy = SeedData.Diner_UserId_01,
                   CreatedAt = DateTime.Now.AddDays(-1)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596306"),
                   ReservationName = "ReservationName_06",
                   NumberOfDiners = 7,
                   ReservationDate = DateTime.Now.AddDays(-12),
                   CreatedBy = SeedData.Diner_UserId_01,
                   CreatedAt = DateTime.Now.AddMonths(-1)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596307"),
                    ReservationName = "ReservationName_07",
                    NumberOfDiners = 9,
                    ReservationDate = DateTime.Now.AddDays(-53),
                    CreatedBy = SeedData.Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddMonths(-2)
                }
                ,
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596308"),
                    ReservationName = "ReservationName_08",
                    NumberOfDiners = 4,
                    ReservationDate = DateTime.Now.AddMonths(5),
                    CreatedBy = SeedData.Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddMonths(4)
                },

            #region Create reservations for user Diner_02
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596309"),
                   ReservationName = "ReservationName_09",
                   NumberOfDiners = 3,
                   ReservationDate = DateTime.Now.AddHours(4),
                   CreatedBy = SeedData.Diner_UserId_02,
                   CreatedAt = DateTime.Now
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596310"),
                   ReservationName = "ReservationName_10",
                   NumberOfDiners = 6,
                   ReservationDate = DateTime.Now.AddHours(7),
                   CreatedBy = SeedData.Diner_UserId_02,
                   CreatedAt = DateTime.Now.AddHours(5)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596311"),
                   ReservationName = "ReservationName_11",
                   NumberOfDiners = 4,
                   ReservationDate = DateTime.Now.AddDays(2),
                   CreatedBy = SeedData.Diner_UserId_02,
                   CreatedAt = DateTime.Now.AddDays(-14)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596312"),
                    ReservationName = "ReservationName_12",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddYears(4),
                    CreatedBy = SeedData.Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddDays(51)
                },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596313"),
                   ReservationName = "ReservationName_13",
                   NumberOfDiners = 9,
                   ReservationDate = DateTime.Now.AddYears(15),
                   CreatedBy = SeedData.Diner_UserId_02,
                   CreatedAt = DateTime.Now.AddMinutes(36)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596314"),
                   ReservationName = "ReservationName_14",
                   NumberOfDiners = 14,
                   ReservationDate = DateTime.Now.AddHours(-4),
                   CreatedBy = SeedData.Diner_UserId_02,
                   CreatedAt = DateTime.Now.AddDays(-2)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596315"),
                   ReservationName = "ReservationName_15",
                   NumberOfDiners = 8,
                   ReservationDate = DateTime.Now.AddDays(-13),
                   CreatedBy = SeedData.Diner_UserId_02,
                   CreatedAt = DateTime.Now.AddMonths(-1)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596316"),
                    ReservationName = "ReservationName_16",
                    NumberOfDiners = 10,
                    ReservationDate = DateTime.Now.AddDays(-50),
                    CreatedBy = SeedData.Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddMonths(-3)
                }
                ,
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596317"),
                    ReservationName = "ReservationName_17",
                    NumberOfDiners = 5,
                    ReservationDate = DateTime.Now.AddMonths(4),
                    CreatedBy = SeedData.Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddMonths(3)
                },

            #region Create reservations for user TajMhal_FoodBusinessManager
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596327"),
                   ReservationName = "ReservationName_27",
                   NumberOfDiners = 3,
                   ReservationDate = DateTime.Now.AddHours(3),
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596328"),
                   ReservationName = "ReservationName_28",
                   NumberOfDiners = 6,
                   ReservationDate = DateTime.Now.AddHours(6),
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddHours(4)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596329"),
                   ReservationName = "ReservationName_29",
                   NumberOfDiners = 4,
                   ReservationDate = DateTime.Now.AddDays(1),
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddDays(-14)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596330"),
                    ReservationName = "ReservationName_30",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddYears(3),
                    CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(55)
                },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596331"),
                   ReservationName = "ReservationName_31",
                   NumberOfDiners = 9,
                   ReservationDate = DateTime.Now.AddYears(13),
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddMinutes(15)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596332"),
                   ReservationName = "ReservationName_32",
                   NumberOfDiners = 14,
                   ReservationDate = DateTime.Now.AddHours(-3),
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddDays(-3)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596333"),
                   ReservationName = "ReservationName_33",
                   NumberOfDiners = 8,
                   ReservationDate = DateTime.Now.AddDays(-10),
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddMonths(-1)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596334"),
                    ReservationName = "ReservationName_34",
                    NumberOfDiners = 10,
                    ReservationDate = DateTime.Now.AddDays(-43),
                    CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMonths(-2)
                }
                ,
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596335"),
                    ReservationName = "ReservationName_35",
                    NumberOfDiners = 5,
                    ReservationDate = DateTime.Now.AddMonths(3),
                    CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMonths(2)
                },

            #region Create reservations for user Mcdonald_FoodBusinessManager
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596336"),
                   ReservationName = "ReservationName_36",
                   NumberOfDiners = 4,
                   ReservationDate = DateTime.Now.AddHours(1),
                   CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596337"),
                   ReservationName = "ReservationName_37",
                   NumberOfDiners = 5,
                   ReservationDate = DateTime.Now.AddHours(4),
                   CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddHours(2)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596338"),
                   ReservationName = "ReservationName_38",
                   NumberOfDiners = 6,
                   ReservationDate = DateTime.Now.AddDays(5),
                   CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddDays(-14)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596339"),
                    ReservationName = "ReservationName_39",
                    NumberOfDiners = 7,
                    ReservationDate = DateTime.Now.AddYears(2),
                    CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(20)
                },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596340"),
                   ReservationName = "ReservationName_40",
                   NumberOfDiners = 10,
                   ReservationDate = DateTime.Now.AddYears(10),
                   CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddMinutes(43)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596341"),
                   ReservationName = "ReservationName_41",
                   NumberOfDiners = 17,
                   ReservationDate = DateTime.Now.AddHours(-12),
                   CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddDays(-5)
               },
               new Reservation
               {
                   FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                   ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596342"),
                   ReservationName = "ReservationName_42",
                   NumberOfDiners = 4,
                   ReservationDate = DateTime.Now.AddDays(-7),
                   CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now.AddMonths(-1)
               },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596343"),
                    ReservationName = "ReservationName_43",
                    NumberOfDiners = 11,
                    ReservationDate = DateTime.Now.AddDays(43),
                    CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMonths(1)
                }
                ,
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596344"),
                    ReservationName = "ReservationName_44",
                    NumberOfDiners = 2,
                    ReservationDate = DateTime.Now.AddMonths(3),
                    CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMonths(2)
                }

                #endregion

            );

            #endregion
        }
    }
}