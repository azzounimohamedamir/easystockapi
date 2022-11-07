using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Infrastructure.Persistence
{
    public static class SeedData
    {
        public const string TajMhal_FoodBusinessId = "3cbf3570-4444-4673-8746-29b7cf568093";
        public const string Mcdonald_FoodBusinessId = "66bf3570-440d-4673-8746-29b7cf568099";
        public const string BigMama_FoodBusinessId = "88bc7853-220f-9173-3246-afb7cf595022";

       


        public const string TajMhal_FoodBusinessAdministrator_UserId = "3cbf3570-4444-4444-8746-29b7cf568093";
        public const string Mcdonald_FoodBusinessAdministrator_UserId = "44bf3570-0d44-4673-8746-29b7cf568088";
        public const string BigMama_FoodBusinessAdministrator_UserId = "08a1a626-7f8e-4b51-84fc-fc51b6302cca";

        public const string TajMhal_FoodBusinessManager_UserId = "a1997466-cedc-4850-b18d-0ac4f4102cff";
        public const string Mcdonald_FoodBusinessManager_UserId = "b2207466-ceda-4b50-b18d-0ac4f4102caa";
        public const string BigMama_SalimFoodBusinessManager_UserId = "64fed988-6f68-49dc-ad54-0da50ec02319";

        public const string TajMhal_Waiter_UserId = "d466ef00-61f1-4e77-801a-b516f0f12323";

        public const string Diner_UserId_01 = "5a84cd00-59f0-4b22-bfce-07c080829118";
        public const string Diner_UserId_02 = "6b14cd00-59f0-4422-bfce-07c080829987";

        public const string TajMhal_VipZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc0";
        public const string TajMhal_FamilyZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc1";
        public const string TajMhal_NormalZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc2";
        public const string TajMhal_OutdoorZone_Id = "32bccd11-59fd-3304-bfaa-07c08082abc3";
        public const string Mcdonald_NormalZone_Id = "32bccd11-59fd-33ff-bfaa-07c08082aba1";
        public const string Mcdonald_OutdoorZone_Id = "32bccd11-59fd-33ff-bfaa-07c08082aba2";
        public const string BigMama_SharedZone_Id = "f60d55e2-4e54-4896-9632-98d36d7680c3";

        public const string TajMhal_VipZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab00";
        public const string TajMhal_FamilyZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab01";
        public const string TajMhal_NormalZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab02";
        public const string TajMhal_OutdoorZone_TableId = "44aecd78-59bb-7504-bfff-07c07129ab03";
        public const string Mcdonald_NormalZone_TableId = "44aecd78-59bb-7504-bfff-07c07129aba2";
        public const string Mcdonald_OutdoorZone_TableId = "44aecd78-59bb-7504-bfff-07c07129aba3";
        public const string BigMama_SharedZone_TableId = "b006e2c5-5b8e-4584-8021-3cecd76c9ca6";

        public const string TajMhal_DishesMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aaba";
        public const string TajMhal_PizzaMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabb";
        public const string TajMhal_SandwichesMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabc";
        public const string TajMhal_BeverageMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabd";
        public const string TajMhal_DessertMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aabe";
        public const string Mcdonald_SandwichesMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aa00";
        public const string Mcdonald_BeverageMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aa01";
        public const string Mcdonald_DessertMenu_Id = "ccaecd78-ccbb-ee04-56ff-88887129aa02";
        public const string BigMama_SandwichesMenu_Id = "e2289d77-b8e1-4476-bf66-e64f1a23d752";
        public const string BigMama_BeverageMenu_Id = "8f8c0139-1f90-40f3-ab88-5db2de45ff2e";
        public const string BigMama_DessertMenu_Id = "45051fc7-6983-44a5-9c12-66116c4533bf";

        public const string Sonatrach_FoodBusinessClientId = "e6f980ba-c381-4319-8b62-da017e116692";
        public const string CEVITAL_FoodBusinessClientId = "1eb2b784-074d-4be4-afb7-9708331c0c63";

        public const string CEVITAL_UserId = "ba89dc5f-dfd1-4c87-9372-233c611cc756";
        public const string Sonatrach_UserId = "a3dbd500-eab0-4233-86fd-7f1a4195f9a9";
        public const string listingId1 = "8087b4c3-b0b0-49e5-b317-85b6b43d97cf";
        public const string listingId2 = "d9099b79-4975-48ca-894c-d92b62b037f0";
        public const string listingId3 = "518c80ef-0dc7-4f6b-b3ba-eed11f4ca9ca";
        public const string listingId4 = "8f98fbfc-ec30-4b71-81c8-f32ed6cd3e65";
        public const string listingId5 = "0bfed7fb-a809-49f2-8c96-381f569abdfd";

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
                    Description =
                        "Envie de découvrir la cuisine indienne, le restaurant Taj Mahal vous invite à le faire et voyager à travers les odeurs des épices orientales qui se dégagent de ses mets à spécialités indiennes.",
                    HasCarParking = true,
                    IsHandicapFriendly = false,
                    OffersTakeout = true,
                    Tags = "",
                    Website = "https://restoalgerie.com/restaurant/taj-mahal-restaurant-indien/",
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
                },

            #endregion

            #region Create a FoodBusiness for BigMama restaurant

                new FoodBusiness
                {
                    FoodBusinessId = Guid.Parse(BigMama_FoodBusinessId),
                    Name = "BigMama",
                    AcceptsCreditCards = true,
                    AcceptTakeout = true,
                    AverageRating = 5,
                    Description =
                        "ETuoYe SMdsYsup qqbdspY NEeZvsaI sUcIOE sVmPkJx RZFk FOKzUkG ffAsUB XyINU fhhIB OiIfN Antdhb XHbtaO UlStFP adgVv CRTToT Mcv FAHcd YyGH. CdDIPW TtDBaI qYg wVcSK NAXHnVC xpNBE fRufEW fggeTKc Iqq dfGZPAqoc MYxnH NCLtDA qqV TNYR LbwaYqv cvIiSvl KBTMl xAxHmu dilIqO mGM kxDhvLT PsYPdCB yZE uFfvGxQp uvoeDsAaE QQjgKs CnAnhrs qNPzSuq bvZjqMfy aaEGCqc XrvE KFXnmA mEnN uGHJt WypGwSiJDmP qBDWYau SzbxbSRUb CMwhBXiYA vQCTdtiB oVkRA XpHYTFE BYFpDTVlV zafiNugG YFyiIvYhhgyzj MihfVEqk OWlRLG YAUn sXWO jbKyczKOQfhXa qziTc xxMFCM WfVzT oPdKGSK Zz CzXeis.",
                    HasCarParking = false,
                    IsHandicapFriendly = false,
                    OffersTakeout = true,
                    Tags = "",
                    Website = "https://bigmama.com",
                    FoodBusinessAdministratorId = BigMama_FoodBusinessAdministrator_UserId,
                    FoodBusinessCategory = FoodBusinessCategory.Restaurant
                }

                #endregion

            );
            #region Create a Hotels

            modelBuilder.Entity<Hotel>().HasData(



                new Hotel
                {
                    Id = Guid.Parse(Mcdonald_FoodBusinessAdministrator_UserId),
                    ImagUrl = "assets/hotels/aurassi.jpg",
                    FoodBusinessAdministratorId = TajMhal_FoodBusinessAdministrator_UserId,
                    Name = "Aurassi",
                }
                ,
                 new Hotel
                 {
                     Id = Guid.Parse(TajMhal_FoodBusinessId),
                     ImagUrl = "assets/hotels/sofitel.jpg",
                     FoodBusinessAdministratorId = TajMhal_FoodBusinessAdministrator_UserId,
                     Name = "Sofitel",
                 }
                 ,
                  new Hotel
                  {
                      Id = Guid.Parse(BigMama_FoodBusinessAdministrator_UserId),
                      ImagUrl = "assets/hotels/tulip.jpg",
                      FoodBusinessAdministratorId = TajMhal_FoodBusinessAdministrator_UserId,
                      Name = "Tulip",
                  }




            ) ;
            #endregion

            #region Assign sofitel hotel to tajmahalfoodbusinessmanager
            modelBuilder.Entity<HotelUser>().HasData(
              new HotelUser
              {
                  ApplicationUserId = TajMhal_FoodBusinessManager_UserId,
                  HotelId = Guid.Parse(TajMhal_FoodBusinessId)
              }
              );
            #endregion

            #region Create listing to sofitel hotel

            modelBuilder.Entity<Listing>(l => {

                l.HasData(new Listing
                {
                    ListingId = Guid.Parse(listingId1),
                    HotelId = Guid.Parse(TajMhal_FoodBusinessId),
                    WithImage = false,
                });

                l.OwnsOne(l => l.Names).HasData(
                    new
                    {
                        ListingId = Guid.Parse(listingId1),
                        AR = "تأجير السيارات",
                        EN = "Car rentals",
                        FR = "locations de voitures",
                        TR = "Araba kiralama",
                        RU = "прокат автомобилей",
                    }
                    );
            });
            modelBuilder.Entity<Listing>(l => {

                l.HasData(new Listing
                {
                    ListingId = Guid.Parse(listingId2),
                    HotelId = Guid.Parse(TajMhal_FoodBusinessId),
                    WithImage = false,
                });

                l.OwnsOne(l => l.Names).HasData(
                    new
                    {
                        ListingId = Guid.Parse(listingId2),
                        AR = "تأجير السيارات",
                        EN = "Car rentals",
                        FR = "locations de voitures",
                        TR = "Araba kiralama",
                        RU = "прокат автомобилей",
                    }
                    );
            });
            modelBuilder.Entity<Listing>(l => {

                l.HasData(new Listing
                {
                    ListingId = Guid.Parse(listingId3),
                    HotelId = Guid.Parse(TajMhal_FoodBusinessId),
                    WithImage = false,
                });

                l.OwnsOne(l => l.Names).HasData(
                    new
                    {
                        ListingId = Guid.Parse(listingId3),
                        AR = "تأجير السيارات",
                        EN = "Car rentals",
                        FR = "locations de voitures",
                        TR = "Araba kiralama",
                        RU = "прокат автомобилей",
                    }
                    );
            });
            modelBuilder.Entity<Listing>(l => {

                l.HasData(new Listing
                {
                    ListingId = Guid.Parse(listingId4),
                    HotelId = Guid.Parse(TajMhal_FoodBusinessId),
                    WithImage = false,
                });

                l.OwnsOne(l => l.Names).HasData(
                    new
                    {
                        ListingId = Guid.Parse(listingId4),
                        AR = "تأجير السيارات",
                        EN = "Car rentals",
                        FR = "locations de voitures",
                        TR = "Araba kiralama",
                        RU = "прокат автомобилей",
                    }
                    );
            });
            modelBuilder.Entity<Listing>(l => {

                l.HasData(new Listing
                {
                    ListingId = Guid.Parse(listingId5),
                    HotelId = Guid.Parse(TajMhal_FoodBusinessId),
                    WithImage = false,
                });

                l.OwnsOne(l => l.Names).HasData(
                    new
                    {
                        ListingId = Guid.Parse(listingId5),
                        AR = "تأجير السيارات",
                        EN = "Car rentals",
                        FR = "locations de voitures",
                        TR = "Araba kiralama",
                        RU = "прокат автомобилей",
                    }
                    );
            });

            #region creating new listing detail to listing 1
            modelBuilder.Entity<ListingDetail>(l => {

                l.HasData(new 
                {
                    Id = Guid.Parse(TajMhal_FoodBusinessId),
                    ListingId = Guid.Parse(listingId1),
                });

                l.OwnsOne(l => l.Names).HasData(
                    new
                    {
                        ListingDetailId = Guid.Parse(TajMhal_FoodBusinessId),
                        AR = "بيكانتو",
                        EN = "Picanto",
                        FR = "Picanto",
                        TR = "Picanto",
                        RU = "прокат автомобилей",
                    }
                    );
            });
            modelBuilder.Entity<ListingDetail>(l => {

                l.HasData(new
                {
                    Id = Guid.Parse(listingId5),
                    ListingId = Guid.Parse(listingId1),
                });

                l.OwnsOne(l => l.Names).HasData(
                    new
                    {
                        ListingDetailId = Guid.Parse(listingId5),
                        AR = "بولو",
                        EN = "Polo",
                        FR = "Polo",
                        TR = "Polo",
                        RU = "прокат автомобилей",
                    }
                    );
            });

            #endregion
            #endregion

            #region Assigning Employees userId with FoodBusinessId (restaurant).

            modelBuilder.Entity<FoodBusinessUser>().HasData(


            #region Assigning account with Id = [TajMhal_FoodBusinessManager_UserId] to TajMhal restaurant.

                new FoodBusinessUser
                {
                    ApplicationUserId = TajMhal_FoodBusinessManager_UserId,
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId)
                },

            #endregion

            #region Assigning account with Id = [TajMhal_Waiter_UserId] to TajMhal restaurant.

                new FoodBusinessUser
                {
                    ApplicationUserId = TajMhal_Waiter_UserId,
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId)
                },

            #endregion

            #region Assigning account with Id = [Mcdonald_FoodBusinessManager_UserId] to Mcdonald restaurant.

                new FoodBusinessUser
                {
                    ApplicationUserId = Mcdonald_FoodBusinessManager_UserId,
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId)
                },

            #endregion

            #region Assigning account with Id = [BigMama_SalimFoodBusinessManager_UserId] to BigMama restaurant.

                new FoodBusinessUser
                {
                    ApplicationUserId = BigMama_SalimFoodBusinessManager_UserId,
                    FoodBusinessId = Guid.Parse(BigMama_FoodBusinessId)
                }

                #endregion

            );

            #endregion

            #region Create reservations

            modelBuilder.Entity<Reservation>().HasData(

            #region Create reservations for user Diner_01

                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596300"),
                    ReservationName = "ReservationName_00",
                    NumberOfDiners = 2,
                    ReservationDate = DateTime.Now.AddHours(5),
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596301"),
                    ReservationName = "ReservationName_01",
                    NumberOfDiners = 5,
                    ReservationDate = DateTime.Now.AddHours(8),
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddHours(5)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596302"),
                    ReservationName = "ReservationName_02",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddDays(1),
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddDays(-15)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596303"),
                    ReservationName = "ReservationName_03",
                    NumberOfDiners = 2,
                    ReservationDate = DateTime.Now.AddYears(5),
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddDays(15)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596304"),
                    ReservationName = "ReservationName_04",
                    NumberOfDiners = 8,
                    ReservationDate = DateTime.Now.AddYears(15),
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddMinutes(36)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596305"),
                    ReservationName = "ReservationName_05",
                    NumberOfDiners = 13,
                    ReservationDate = DateTime.Now.AddHours(-3),
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596306"),
                    ReservationName = "ReservationName_06",
                    NumberOfDiners = 7,
                    ReservationDate = DateTime.Now.AddDays(-12),
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddMonths(-1)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596307"),
                    ReservationName = "ReservationName_07",
                    NumberOfDiners = 9,
                    ReservationDate = DateTime.Now.AddDays(-53),
                    CreatedBy = Diner_UserId_01,
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
                    CreatedBy = Diner_UserId_01,
                    CreatedAt = DateTime.Now.AddMonths(4)
                },

            #endregion

            #region Create reservations for user Diner_02

                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596309"),
                    ReservationName = "ReservationName_09",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddHours(4),
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596310"),
                    ReservationName = "ReservationName_10",
                    NumberOfDiners = 6,
                    ReservationDate = DateTime.Now.AddHours(7),
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddHours(5)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596311"),
                    ReservationName = "ReservationName_11",
                    NumberOfDiners = 4,
                    ReservationDate = DateTime.Now.AddDays(2),
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddDays(-14)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596312"),
                    ReservationName = "ReservationName_12",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddYears(4),
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddDays(51)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596313"),
                    ReservationName = "ReservationName_13",
                    NumberOfDiners = 9,
                    ReservationDate = DateTime.Now.AddYears(15),
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddMinutes(36)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596314"),
                    ReservationName = "ReservationName_14",
                    NumberOfDiners = 14,
                    ReservationDate = DateTime.Now.AddHours(-4),
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596315"),
                    ReservationName = "ReservationName_15",
                    NumberOfDiners = 8,
                    ReservationDate = DateTime.Now.AddDays(-13),
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddMonths(-1)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596316"),
                    ReservationName = "ReservationName_16",
                    NumberOfDiners = 10,
                    ReservationDate = DateTime.Now.AddDays(-50),
                    CreatedBy = Diner_UserId_02,
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
                    CreatedBy = Diner_UserId_02,
                    CreatedAt = DateTime.Now.AddMonths(3)
                },

            #endregion

            #region Create reservations for user TajMhal_FoodBusinessManager

                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596327"),
                    ReservationName = "ReservationName_27",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddHours(3),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596328"),
                    ReservationName = "ReservationName_28",
                    NumberOfDiners = 6,
                    ReservationDate = DateTime.Now.AddHours(6),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddHours(4)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596329"),
                    ReservationName = "ReservationName_29",
                    NumberOfDiners = 4,
                    ReservationDate = DateTime.Now.AddDays(1),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(-14)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596330"),
                    ReservationName = "ReservationName_30",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddYears(3),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(55)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596331"),
                    ReservationName = "ReservationName_31",
                    NumberOfDiners = 9,
                    ReservationDate = DateTime.Now.AddYears(13),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMinutes(15)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596332"),
                    ReservationName = "ReservationName_32",
                    NumberOfDiners = 14,
                    ReservationDate = DateTime.Now.AddHours(-3),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596333"),
                    ReservationName = "ReservationName_33",
                    NumberOfDiners = 8,
                    ReservationDate = DateTime.Now.AddDays(-10),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMonths(-1)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596334"),
                    ReservationName = "ReservationName_34",
                    NumberOfDiners = 10,
                    ReservationDate = DateTime.Now.AddDays(-43),
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
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
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMonths(2)
                },

            #endregion

            #region Create reservations for user Mcdonald_FoodBusinessManager

                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596336"),
                    ReservationName = "ReservationName_36",
                    NumberOfDiners = 4,
                    ReservationDate = DateTime.Now.AddHours(1),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596337"),
                    ReservationName = "ReservationName_37",
                    NumberOfDiners = 5,
                    ReservationDate = DateTime.Now.AddHours(4),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddHours(2)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596338"),
                    ReservationName = "ReservationName_38",
                    NumberOfDiners = 6,
                    ReservationDate = DateTime.Now.AddDays(5),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(-14)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596339"),
                    ReservationName = "ReservationName_39",
                    NumberOfDiners = 7,
                    ReservationDate = DateTime.Now.AddYears(2),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(20)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596340"),
                    ReservationName = "ReservationName_40",
                    NumberOfDiners = 10,
                    ReservationDate = DateTime.Now.AddYears(10),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMinutes(43)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596341"),
                    ReservationName = "ReservationName_41",
                    NumberOfDiners = 17,
                    ReservationDate = DateTime.Now.AddHours(-12),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596342"),
                    ReservationName = "ReservationName_42",
                    NumberOfDiners = 4,
                    ReservationDate = DateTime.Now.AddDays(-7),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now.AddMonths(-1)
                },
                new Reservation
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ReservationId = Guid.Parse("acbf657b-3398-7a73-8746-77b7cf596343"),
                    ReservationName = "ReservationName_43",
                    NumberOfDiners = 11,
                    ReservationDate = DateTime.Now.AddDays(43),
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
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
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
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
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ZoneTitle = "TajMhal VIP Zone",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(TajMhal_VipZone_Id)
                },
                new Zone
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ZoneTitle = "TajMhal FAMILY Zone",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(TajMhal_FamilyZone_Id)
                },
                new Zone
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ZoneTitle = "TajMhal NORMAL Zone",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(TajMhal_NormalZone_Id)
                },
                new Zone
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    ZoneTitle = "TajMhal OUTDOOR Zone",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(TajMhal_OutdoorZone_Id)
                },

            #endregion

            #region Create zones for Mcdonald_FoodBusiness

                new Zone
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ZoneTitle = "Mcdonald NORMAL Zone",
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(Mcdonald_NormalZone_Id)
                },
                new Zone
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    ZoneTitle = "Mcdonald OUTDOOR Zone",
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(Mcdonald_OutdoorZone_Id)
                },

            #endregion

            #region Create zones for BigMama_FoodBusiness

                new Zone
                {
                    FoodBusinessId = Guid.Parse(BigMama_FoodBusinessId),
                    ZoneTitle = "BigMama SHARED Zone",
                    CreatedBy = BigMama_SalimFoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    ZoneId = Guid.Parse(BigMama_SharedZone_Id)
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
                    TableNumber = 1,
                    Capacity = 4,
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(TajMhal_VipZone_TableId)
                },
                new Table
                {
                    ZoneId = Guid.Parse(TajMhal_FamilyZone_Id),
                    TableNumber = 2,
                    Capacity = 6,
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(TajMhal_FamilyZone_TableId)
                },
                new Table
                {
                    ZoneId = Guid.Parse(TajMhal_NormalZone_Id),
                    TableNumber = 4,
                    Capacity = 4,
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(TajMhal_NormalZone_TableId)
                },
                new Table
                {
                    ZoneId = Guid.Parse(TajMhal_OutdoorZone_Id),
                    TableNumber = 5,
                    Capacity = 3,
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(TajMhal_OutdoorZone_TableId)
                },

            #endregion

            #region Create tables for Mcdonald_FoodBusiness

                new Table
                {
                    ZoneId = Guid.Parse(Mcdonald_NormalZone_Id),
                    TableNumber = 1,
                    Capacity = 5,
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(Mcdonald_NormalZone_TableId)
                },
                new Table
                {
                    ZoneId = Guid.Parse(Mcdonald_OutdoorZone_Id),
                    TableNumber = 2,
                    Capacity = 3,
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(Mcdonald_OutdoorZone_TableId)
                },

            #endregion

            #region Create tables for BigMama_FoodBusiness

                new Table
                {
                    ZoneId = Guid.Parse(BigMama_SharedZone_Id),
                    TableNumber = 1,
                    Capacity = 6,
                    CreatedBy = BigMama_SalimFoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    TableId = Guid.Parse(BigMama_SharedZone_TableId)
                }

                #endregion

            );

            #endregion

            #region Create menus

            modelBuilder.Entity<Menu>().HasData(

            #region Create menus for TajMhal_FoodBusiness

                new Menu
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    Name = "TajMhal Dishes Menu",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(TajMhal_DishesMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    Name = "TajMhal Pizza Menu",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(TajMhal_PizzaMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    Name = "TajMhal Sandwiches Menu",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(TajMhal_SandwichesMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    Name = "TajMhal Beverage  Menu",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(TajMhal_BeverageMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    Name = "TajMhal Dessert Menu",
                    CreatedBy = TajMhal_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(TajMhal_DessertMenu_Id)
                },

            #endregion

            #region Create menus for Mcdonald_FoodBusiness

                new Menu
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    Name = "Mcdonald Sandwiches Menu",
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(Mcdonald_SandwichesMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    Name = "Mcdonald Beverage  Menu",
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(Mcdonald_BeverageMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(Mcdonald_FoodBusinessId),
                    Name = "Mcdonald Dessert Menu",
                    CreatedBy = Mcdonald_FoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(Mcdonald_DessertMenu_Id)
                },

            #endregion

            #region Create menus for BigMama_FoodBusiness

                new Menu
                {
                    FoodBusinessId = Guid.Parse(BigMama_FoodBusinessId),
                    Name = "BigMama Sandwiches Menu",
                    CreatedBy = BigMama_SalimFoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(BigMama_SandwichesMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(BigMama_FoodBusinessId),
                    Name = "BigMama Beverage  Menu",
                    CreatedBy = BigMama_SalimFoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(BigMama_BeverageMenu_Id)
                },
                new Menu
                {
                    FoodBusinessId = Guid.Parse(BigMama_FoodBusinessId),
                    Name = "BigMama Dessert Menu",
                    CreatedBy = BigMama_SalimFoodBusinessManager_UserId,
                    CreatedAt = DateTime.Now,
                    MenuId = Guid.Parse(BigMama_DessertMenu_Id)
                }

                #endregion

            );

            #endregion

            #region Create FoodBusinessClient
            // TODO : Create FoodBusiness Client

            #region Create Sonatrach Entreprise

            modelBuilder.Entity<FoodBusinessClient>().HasData(
                new FoodBusinessClient
                {
                    FoodBusinessClientId = Guid.Parse(Sonatrach_FoodBusinessClientId),
                    Name = "Sonatrach",
                    Description = "SONATRACH est la première entreprise du continent africain. Une société intégrée de l'Amont à l'Aval pétrolier et gazier et un Groupe internationale.",
                    Website = "https://sonatrach.com/",
                    ManagerId = Sonatrach_UserId,
                    FoodBusinessId = Guid.Parse(TajMhal_FoodBusinessId),
                    Archived = false
                },
            #endregion
            #region Create CEVITAL Entreprise
                new FoodBusinessClient
                {
                    FoodBusinessClientId = Guid.Parse(CEVITAL_FoodBusinessClientId),
                    Name = "CEVITAL",
                    Description = "Cevital is a family-run Group whose success and reputation are rooted in its history, its track record and its values.",
                    Website = "https://cevital.com/",
                    ManagerId = CEVITAL_UserId,
                    FoodBusinessId = Guid.Parse(BigMama_FoodBusinessId),
                    Archived = false
                }
                #endregion
            );
            #endregion
        }
    }
}
#endregion
