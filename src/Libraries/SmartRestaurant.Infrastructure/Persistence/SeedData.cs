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

        public const string TajMhal_VipZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc0";
        public const string TajMhal_FamilyZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc1";
        public const string TajMhal_NormalZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc2";
        public const string TajMhal_OutdoorZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc3";
        public const string Mcdonald_NormalZone_Id = "32bccd11-59fd-33ff-bfaa-07c08082aba1";
        public const string Mcdonald_OutdoorZone_Id = "32bccd11-59fd-33ff-bfaa-07c08082aba2";

        public const string TajMhal_VipZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab00";
        public const string TajMhal_FamilyZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab01";
        public const string TajMhal_NormalZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab02";
        public const string TajMhal_OutdoorZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab03";
        public const string Mcdonald_NormalZone_TableId = "44aecd78-59bb-7504-bfff-07c07129aba2";
        public const string Mcdonald_OutdoorZone_TableId = "44aecd78-59bb-7504-bfff-07c07129aba3";

        public const string TajMhal_DishesMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aaba";
        public const string TajMhal_PizzaMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabb";
        public const string TajMhal_SandwichesMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabc";
        public const string TajMhal_BeverageMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabd";
        public const string TajMhal_DessertMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabe";
        public const string Mcdonald_SandwichesMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aa00";
        public const string Mcdonald_BeverageMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aa01";
        public const string Mcdonald_DessertMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aa02";

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Create a FoodBusinesses 
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


            #region Assigning Employees userId with FoodBusinessId (restaurant). 
            modelBuilder.Entity<FoodBusinessUser>().HasData(

                #region Assigning account with Id = [TajMhal_FoodBusinessAdministrator_UserId] to TajMhal restaurant.
                new FoodBusinessUser
                {
                    ApplicationUserId = TajMhal_FoodBusinessAdministrator_UserId,
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                },
                #endregion

                #region Assigning account with Id = [TajMhal_FoodBusinessManager_UserId] to TajMhal restaurant.
                new FoodBusinessUser
                {
                    ApplicationUserId = TajMhal_FoodBusinessManager_UserId,
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                },
                #endregion

                #region Assigning account with Id = [Mcdonald_FoodBusinessAdministrator_UserId] to Mcdonald restaurant.
                new FoodBusinessUser
                {
                    ApplicationUserId = Mcdonald_FoodBusinessAdministrator_UserId,
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                },
                #endregion

                #region Assigning account with Id = [Mcdonald_FoodBusinessManager_UserId] to Mcdonald restaurant.
                new FoodBusinessUser
                {
                    ApplicationUserId = Mcdonald_FoodBusinessManager_UserId,
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
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
            #endregion
            
           
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
            #endregion
            
                
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
            #endregion
           
                
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

            #region Create zones
            modelBuilder.Entity<Zone>().HasData(

            #region Create zones for TajMhal_FoodBusiness
               new Zone
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   ZoneTitle = "TajMhal VIP Zone",
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now,
                   ZoneId = Guid.Parse(TajMhal_VipZone_Id)
               },
                new Zone
                {
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    ZoneTitle = "TajMhal FAMILY Zone",
                    CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(TajMhal_FamilyZone_Id)
                },
                new Zone
                {
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    ZoneTitle = "TajMhal NORMAL Zone",
                    CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(TajMhal_NormalZone_Id)
                },
                 new Zone
                 {
                     FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                     ZoneTitle = "TajMhal OUTDOOR Zone",
                     CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     ZoneId = Guid.Parse(TajMhal_OutdoorZone_Id)
                 },
            #endregion

            #region Create zones for Mcdonald_FoodBusiness
                new Zone
                {
                    FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                    ZoneTitle = "Mcdonald NORMAL Zone",
                    CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(Mcdonald_NormalZone_Id)
                },
                 new Zone
                 {
                     FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                     ZoneTitle = "Mcdonald OUTDOOR Zone",
                     CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     ZoneId = Guid.Parse(Mcdonald_OutdoorZone_Id)
                 }
            #endregion
            );
            #endregion

            #region Create tables
            modelBuilder.Entity<Table>().HasData(

            #region Create tables for TajMhal_FoodBusiness
               new Table
               {
                   ZoneId = Guid.Parse(TajMhal_VipZone_Id),
                   TableNumber = 4,
                   Capacity = 4,                   
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now,
                   TableId = Guid.Parse(TajMhal_VipZone_TableId)                                      
               },
               new Table
               {

                   ZoneId = Guid.Parse(TajMhal_FamilyZone_Id),
                   TableNumber = 5,
                   Capacity = 6,
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now,
                   TableId = Guid.Parse(TajMhal_FamilyZone_TableId)
               },
                new Table
                {
                    ZoneId = Guid.Parse(TajMhal_NormalZone_Id),
                    TableNumber = 10,
                    Capacity = 4,
                    CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(TajMhal_NormalZone_TableId)
                },
                 new Table
                 {
                     ZoneId = Guid.Parse(TajMhal_OutdoorZone_Id),
                     TableNumber = 7,
                     Capacity = 3,
                     CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     TableId = Guid.Parse(TajMhal_OutdoorZone_TableId)
                 },

            #endregion

            #region Create tables for Mcdonald_FoodBusiness
                new Table
                {
                    ZoneId = Guid.Parse(Mcdonald_NormalZone_Id),
                    TableNumber = 7,
                    Capacity = 5,
                    CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(Mcdonald_NormalZone_TableId)
                },
                 new Table
                 {
                     ZoneId = Guid.Parse(Mcdonald_OutdoorZone_Id),
                     TableNumber = 3,
                     Capacity = 3,
                     CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     TableId = Guid.Parse(Mcdonald_OutdoorZone_TableId)
                 }
            #endregion
            );

            #endregion
            
            #region Create menus
            modelBuilder.Entity<Menu>().HasData(

            #region Create menus for TajMhal_FoodBusiness
               new Menu
               {
                   FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                   Name = "TajMhal Dishes Menu",
                   CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                   CreatedAt = DateTime.Now,
                   MenuId = Guid.Parse(TajMhal_DishesMenu_Id)
               },
                 new Menu
                 {
                     FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                     Name = "TajMhal Pizza Menu",
                     CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     MenuId = Guid.Parse(TajMhal_PizzaMenu_Id)
                 },
                 new Menu
                 {
                     FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                     Name = "TajMhal Sandwiches Menu",
                     CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     MenuId = Guid.Parse(TajMhal_SandwichesMenu_Id)
                 },
                 new Menu
                 {
                     FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                     Name = "TajMhal Beverage  Menu",
                     CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     MenuId = Guid.Parse(TajMhal_BeverageMenu_Id)
                 },
                  new Menu
                  {
                      FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                      Name = "TajMhal Dessert Menu",
                      CreatedBy = SeedData.TajMhal_FoodBusinessManager_UserId,
                      CreatedAt = DateTime.Now,
                      MenuId = Guid.Parse(TajMhal_DessertMenu_Id)
                  },
            #endregion

            #region Create menus for Mcdonald_FoodBusiness
                 new Menu
                 {
                     FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                     Name = "Mcdonald Sandwiches Menu",
                     CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     MenuId = Guid.Parse(Mcdonald_SandwichesMenu_Id)
                 },
                 new Menu
                 {
                     FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                     Name = "Mcdonald Beverage  Menu",
                     CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                     CreatedAt = DateTime.Now,
                     MenuId = Guid.Parse(Mcdonald_BeverageMenu_Id)
                 },
                  new Menu
                  {
                      FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                      Name = "Mcdonald Dessert Menu",
                      CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId,
                      CreatedAt = DateTime.Now,
                      MenuId = Guid.Parse(Mcdonald_DessertMenu_Id)
                  }
            #endregion
            );
            #endregion
        }
    }
}