using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;
using System;

namespace SmartRestaurant.Infrastructure.Identity.Persistence
{
    public static class SeedData
    {
        public const string TajMhal_FoodBusinessAdministrator_UserId = "3cbf3570-4444-4444-8746-29b7cf568093";
        public const string Mcdonald_FoodBusinessAdministrator_UserId = "44bf3570-0d44-4673-8746-29b7cf568088";
        public const string BigMama_FoodBusinessAdministrator_UserId = "08a1a626-7f8e-4b51-84fc-fc51b6302cca";

        public const string TajMhal_FoodBusinessManager_UserId = "a1997466-cedc-4850-b18d-0ac4f4102cff";
        public const string Mcdonald_FoodBusinessManager_UserId = "b2207466-ceda-4b50-b18d-0ac4f4102caa";
        public const string BigMama_SalimFoodBusinessManager_UserId = "64fed988-6f68-49dc-ad54-0da50ec02319";

        public const string Diner_UserId_01 = "5a84cd00-59f0-4b22-bfce-07c080829118";
        public const string Diner_UserId_02 = "6b14cd00-59f0-4422-bfce-07c080829987";

        public const string CEVITAL_UserId = "ba89dc5f-dfd1-4c87-9372-233c611cc756";
        public const string Sonatrach_UserId = "a3dbd500-eab0-4233-86fd-7f1a4195f9a9";
        public const string HotelManager_userID = "6d215fd5-e7b4-4afd-aa6c-334a37d3874d";
        public const string HotelReceptionist_UserId = "83e72357-25b8-4e2a-8728-3e25365608e2";
        public const string HotelServiceAdmin_userId = "C4EAACBE-A5C5-47E8-8DED-508709D7A50F";
        public const string ClientHotel_UserId = "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D";
        public const string HotelServiceTechnique_UserId = "acd04fc6-99da-436f-a011-191b7e92aa23";
        public const string HouseKeeping_UserId = "7d33ae49-68a8-4c10-bc57-b09da6f9f016";

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Create application Roles

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = ((long)Roles.SuperAdmin).ToString(),
                    Name = Roles.SuperAdmin.ToString(),
                    NormalizedName = Roles.SuperAdmin.ToString().ToUpper(),
                    ConcurrencyStamp = "88f0dec2-5364-4881-4817-1f2a135a8641"
                },

                new ApplicationRole
                {
                    Id = ((long)Roles.Manager).ToString(),
                    Name = Roles.Manager.ToString(),
                    NormalizedName = Roles.Manager.ToString().ToUpper(),
                    ConcurrencyStamp = "1933aad7-120c-414f-a575-5681df13732f"
                },
                  new ApplicationRole
                  {
                      Id = ((long)Roles.GestionnaireVente).ToString(),
                      Name = Roles.GestionnaireVente.ToString(),
                      NormalizedName = Roles.GestionnaireVente.ToString().ToUpper(),
                      ConcurrencyStamp = "b9182488-5482-4051-af9d-5fea22182944"
                  },
                   new ApplicationRole
                   {
                       Id = ((long)Roles.GestionnaireStock).ToString(),
                       Name = Roles.GestionnaireStock.ToString(),
                       NormalizedName = Roles.GestionnaireStock.ToString().ToUpper(),
                       ConcurrencyStamp = "6f3d452f-28a5-42be-b474-716985d97820"
                   },
                    new ApplicationRole
                    {
                        Id = ((long)Roles.GestionnaireAchat).ToString(),
                        Name = Roles.GestionnaireAchat.ToString(),
                        NormalizedName = Roles.GestionnaireAchat.ToString().ToUpper(),
                        ConcurrencyStamp = "5050daa0-8870-4450-8004-23d11aa0cc4a"
                    },
                    new ApplicationRole
                    {
                        Id = ((long)Roles.CaissierFacturier).ToString(),
                        Name = Roles.CaissierFacturier.ToString(),
                        NormalizedName = Roles.CaissierFacturier.ToString().ToUpper(),
                        ConcurrencyStamp = "0c845a63-6573-488a-9c89-a50484707e88"
                    },

                     new ApplicationRole
                     {
                         Id = ((long)Roles.Caissier).ToString(),
                         Name = Roles.Caissier.ToString(),
                         NormalizedName = Roles.Caissier.ToString().ToUpper(),
                         ConcurrencyStamp = "27dcec7a-0048-4e46-9cf5-292a4a59c171"
                     },

                new ApplicationRole
                {
                    Id = ((long)Roles.SupportAgent).ToString(),
                    Name = Roles.SupportAgent.ToString(),
                    NormalizedName = Roles.SupportAgent.ToString().ToUpper(),
                    ConcurrencyStamp = "emec7115-422c-487d-65b0-58cfa8e66a94"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.SalesMan).ToString(),
                    Name = Roles.SalesMan.ToString(),
                    NormalizedName = Roles.SalesMan.ToString().ToUpper(),
                    ConcurrencyStamp = "emrc7115-422c-487d-75b0-58cfa8e66a94"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.Photograph).ToString(),
                    Name = Roles.Photograph.ToString(),
                    NormalizedName = Roles.Photograph.ToString().ToUpper(),
                    ConcurrencyStamp = "emtc7115-422c-487d-85b0-58cfa8e66a94"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.FoodBusinessAdministrator).ToString(),
                    Name = Roles.FoodBusinessAdministrator.ToString(),
                    NormalizedName = Roles.FoodBusinessAdministrator.ToString().ToUpper(),
                    ConcurrencyStamp = "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d2"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.FoodBusinessManager).ToString(),
                    Name = Roles.FoodBusinessManager.ToString(),
                    NormalizedName = Roles.FoodBusinessManager.ToString().ToUpper(),
                    ConcurrencyStamp = "emcc7115-422c-487d-95b0-58cfa8e66a94"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.FoodBusinessOwner).ToString(),
                    Name = Roles.FoodBusinessOwner.ToString(),
                    NormalizedName = Roles.FoodBusinessOwner.ToString().ToUpper(),
                    ConcurrencyStamp = "emcb7115-422c-487d-95c0-58cfa8m66a94"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.Cashier).ToString(),
                    Name = Roles.Cashier.ToString(),
                    NormalizedName = Roles.Cashier.ToString().ToUpper(),
                    ConcurrencyStamp = "encc7115-422c-487d-95b0-58cfa8e66a95"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.Chef).ToString(),
                    Name = Roles.Chef.ToString(),
                    NormalizedName = Roles.Chef.ToString().ToUpper(),
                    ConcurrencyStamp = "elcc7115-422c-487d-95b0-58cfa8e66a96"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.Waiter).ToString(),
                    Name = Roles.Waiter.ToString(),
                    NormalizedName = Roles.Waiter.ToString().ToUpper(),
                    ConcurrencyStamp = "ekcc7115-422c-487d-95b0-58cfa8e66a97"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.Diner).ToString(),
                    Name = Roles.Diner.ToString(),
                    NormalizedName = Roles.Diner.ToString().ToUpper(),
                    ConcurrencyStamp = "edcc7115-422c-487d-95b0-58cfa8e66a98"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.Anounymous).ToString(),
                    Name = Roles.Anounymous.ToString(),
                    NormalizedName = Roles.Anounymous.ToString().ToUpper(),
                    ConcurrencyStamp = "educ7115-422c-487d-25b0-58cfa8e66a98"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.Organization).ToString(),
                    Name = Roles.Organization.ToString(),
                    NormalizedName = Roles.Organization.ToString().ToUpper(),
                    ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.HotelManager).ToString(),
                    Name = Roles.HotelManager.ToString(),
                    NormalizedName = Roles.HotelManager.ToString().ToUpper(),
                    ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98"
                }
                ,
                new ApplicationRole
                {
                    Id = ((long)Roles.HotelReceptionist).ToString(),
                    Name = Roles.HotelReceptionist.ToString(),
                    NormalizedName = Roles.HotelReceptionist.ToString().ToUpper(),
                    ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98"
                }
                ,
                new ApplicationRole
                {
                    Id = ((long)Roles.HotelServiceAdmin).ToString(),
                    Name = Roles.HotelServiceAdmin.ToString(),
                    NormalizedName = Roles.HotelServiceAdmin.ToString().ToUpper(),
                    ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98"
                }
                ,
                new ApplicationRole
                {
                    Id = ((long)Roles.HotelClient).ToString(),
                    Name = Roles.HotelClient.ToString(),
                    NormalizedName = Roles.HotelClient.ToString().ToUpper(),
                    ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98"
                },
                new ApplicationRole
                {
                    Id = ((long)Roles.HotelServiceTechnique).ToString(),
                    Name = Roles.HotelServiceTechnique.ToString(),
                    NormalizedName = Roles.HotelServiceTechnique.ToString().ToUpper(),
                    ConcurrencyStamp = "270b4553-f9b8-48e0-b244-af2ce4bc5ca9"
                },
                 new ApplicationRole
                 {
                     Id = ((long)Roles.HouseKeeping).ToString(),
                     Name = Roles.HouseKeeping.ToString(),
                     NormalizedName = Roles.HouseKeeping.ToString().ToUpper(),
                     ConcurrencyStamp = "2622be83-085c-4339-ae68-ffa9d5cd2fa8"
                 }
            );

            #endregion


            #region Create applications users

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "3cbf3570-0d44-4673-8746-29b7cf568093",
                    UserName = "admin@easystock.com",
                    Email = "admin@easystock.com",
                    NormalizedUserName = "admin@EASYSTOCK.COM",
                    NormalizedEmail = "admin@EASYSTOCK.COM",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                    EmailConfirmed = true
                },
                 new ApplicationUser
                 {
                     Id = "eed390c0-759f-4daa-856c-a0433345e8cd",
                     UserName = "caisse01@easystock.com",
                     Email = "caisse01@easystock.com",
                     NormalizedUserName = "caisse01@EASYSTOCK.COM",
                     NormalizedEmail = "caisse01@EASYSTOCK.COM",
                     PasswordHash =
                        "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                     EmailConfirmed = true
                 }



            );

            #endregion


            #region Set Users Roles

            modelBuilder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole
                {
                    UserId = "3cbf3570-0d44-4673-8746-29b7cf568093",
                    RoleId = "1"
                },
                new ApplicationUserRole
                {
                    UserId = "eed390c0-759f-4daa-856c-a0433345e8cd",
                    RoleId = "21"
                }


            );

            #endregion
            #region Set Users Permissions

            modelBuilder.Entity<Permissions>().HasData(
                new Permissions
                {
                    Id = Guid.Parse("ed2bc9e3-6f4d-428a-be99-106d6e728734"),
                    Role = "SuperAdmin",
                    Ba = true,
                    Vc = true,
                    Clients = true,
                    Bca = true,
                    Bcv = true,
                    StockAlerte = true,
                    Bl = true,
                    Stocks = true,
                    CreancesAss = true,
                    Fac = true,
                    FacAvoir = true,
                    Facpro = true,
                    Familles = true,
                    Fournisseurs = true,
                    Gda = true,
                    Gde = true,
                    Gds = true,
                    Gdv = true,
                    Inventaires = true,
                    Inviter = true,
                    Marques = true,
                    RegFour = true,
                    RetoursProdClient = true,
                    RetoursProdFour = true,
                    Unites = true,
                    RegClients = true,

                }


            );

            #endregion

        }
    }
}