﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartRestaurant.Infrastructure.Identity.Persistence;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20250218084308_AddPermissionOfAdminInSeed")]
    partial class AddPermissionOfAdminInSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartRestaurant.Domain.Identity.Entities.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "88f0dec2-5364-4881-4817-1f2a135a8641",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "20",
                            ConcurrencyStamp = "1933aad7-120c-414f-a575-5681df13732f",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "24",
                            ConcurrencyStamp = "b9182488-5482-4051-af9d-5fea22182944",
                            Name = "GestionnaireVente",
                            NormalizedName = "GESTIONNAIREVENTE"
                        },
                        new
                        {
                            Id = "23",
                            ConcurrencyStamp = "6f3d452f-28a5-42be-b474-716985d97820",
                            Name = "GestionnaireStock",
                            NormalizedName = "GESTIONNAIRESTOCK"
                        },
                        new
                        {
                            Id = "25",
                            ConcurrencyStamp = "5050daa0-8870-4450-8004-23d11aa0cc4a",
                            Name = "GestionnaireAchat",
                            NormalizedName = "GESTIONNAIREACHAT"
                        },
                        new
                        {
                            Id = "22",
                            ConcurrencyStamp = "0c845a63-6573-488a-9c89-a50484707e88",
                            Name = "CaissierFacturier",
                            NormalizedName = "CAISSIERFACTURIER"
                        },
                        new
                        {
                            Id = "21",
                            ConcurrencyStamp = "27dcec7a-0048-4e46-9cf5-292a4a59c171",
                            Name = "Caissier",
                            NormalizedName = "CAISSIER"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "emec7115-422c-487d-65b0-58cfa8e66a94",
                            Name = "SupportAgent",
                            NormalizedName = "SUPPORTAGENT"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "emrc7115-422c-487d-75b0-58cfa8e66a94",
                            Name = "SalesMan",
                            NormalizedName = "SALESMAN"
                        },
                        new
                        {
                            Id = "4",
                            ConcurrencyStamp = "emtc7115-422c-487d-85b0-58cfa8e66a94",
                            Name = "Photograph",
                            NormalizedName = "PHOTOGRAPH"
                        },
                        new
                        {
                            Id = "5",
                            ConcurrencyStamp = "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d2",
                            Name = "FoodBusinessAdministrator",
                            NormalizedName = "FOODBUSINESSADMINISTRATOR"
                        },
                        new
                        {
                            Id = "6",
                            ConcurrencyStamp = "emcc7115-422c-487d-95b0-58cfa8e66a94",
                            Name = "FoodBusinessManager",
                            NormalizedName = "FOODBUSINESSMANAGER"
                        },
                        new
                        {
                            Id = "7",
                            ConcurrencyStamp = "emcb7115-422c-487d-95c0-58cfa8m66a94",
                            Name = "FoodBusinessOwner",
                            NormalizedName = "FOODBUSINESSOWNER"
                        },
                        new
                        {
                            Id = "9",
                            ConcurrencyStamp = "encc7115-422c-487d-95b0-58cfa8e66a95",
                            Name = "Cashier",
                            NormalizedName = "CASHIER"
                        },
                        new
                        {
                            Id = "8",
                            ConcurrencyStamp = "elcc7115-422c-487d-95b0-58cfa8e66a96",
                            Name = "Chef",
                            NormalizedName = "CHEF"
                        },
                        new
                        {
                            Id = "10",
                            ConcurrencyStamp = "ekcc7115-422c-487d-95b0-58cfa8e66a97",
                            Name = "Waiter",
                            NormalizedName = "WAITER"
                        },
                        new
                        {
                            Id = "11",
                            ConcurrencyStamp = "edcc7115-422c-487d-95b0-58cfa8e66a98",
                            Name = "Diner",
                            NormalizedName = "DINER"
                        },
                        new
                        {
                            Id = "12",
                            ConcurrencyStamp = "educ7115-422c-487d-25b0-58cfa8e66a98",
                            Name = "Anounymous",
                            NormalizedName = "ANOUNYMOUS"
                        },
                        new
                        {
                            Id = "13",
                            ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98",
                            Name = "Organization",
                            NormalizedName = "ORGANIZATION"
                        },
                        new
                        {
                            Id = "14",
                            ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98",
                            Name = "HotelManager",
                            NormalizedName = "HOTELMANAGER"
                        },
                        new
                        {
                            Id = "15",
                            ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98",
                            Name = "HotelReceptionist",
                            NormalizedName = "HOTELRECEPTIONIST"
                        },
                        new
                        {
                            Id = "16",
                            ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98",
                            Name = "HotelServiceAdmin",
                            NormalizedName = "HOTELSERVICEADMIN"
                        },
                        new
                        {
                            Id = "17",
                            ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98",
                            Name = "HotelClient",
                            NormalizedName = "HOTELCLIENT"
                        },
                        new
                        {
                            Id = "18",
                            ConcurrencyStamp = "270b4553-f9b8-48e0-b244-af2ce4bc5ca9",
                            Name = "HotelServiceTechnique",
                            NormalizedName = "HOTELSERVICETECHNIQUE"
                        },
                        new
                        {
                            Id = "19",
                            ConcurrencyStamp = "2622be83-085c-4339-ae68-ffa9d5cd2fa8",
                            Name = "HouseKeeping",
                            NormalizedName = "HOUSEKEEPING"
                        });
                });

            modelBuilder.Entity("SmartRestaurant.Domain.Identity.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsShowPhoneNumberInOdoo")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Mac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "3cbf3570-0d44-4673-8746-29b7cf568093",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "84eda78c-f266-49e0-87d7-aaf674fd942c",
                            Email = "admin@easystock.com",
                            EmailConfirmed = true,
                            IsActive = true,
                            IsShowPhoneNumberInOdoo = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@EASYSTOCK.COM",
                            NormalizedUserName = "admin@EASYSTOCK.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f0886dd2-f3aa-483b-8661-314f4cdbf64a",
                            TwoFactorEnabled = false,
                            UserName = "admin@easystock.com"
                        },
                        new
                        {
                            Id = "eed390c0-759f-4daa-856c-a0433345e8cd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9014e44f-d7dc-4a9c-9260-0d6ac5dc829b",
                            Email = "caisse01@easystock.com",
                            EmailConfirmed = true,
                            IsActive = true,
                            IsShowPhoneNumberInOdoo = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "caisse01@EASYSTOCK.COM",
                            NormalizedUserName = "caisse01@EASYSTOCK.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d99cad9e-a82b-4249-9d3e-d659e776f577",
                            TwoFactorEnabled = false,
                            UserName = "caisse01@easystock.com"
                        });
                });

            modelBuilder.Entity("SmartRestaurant.Domain.Identity.Entities.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "3cbf3570-0d44-4673-8746-29b7cf568093",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "eed390c0-759f-4daa-856c-a0433345e8cd",
                            RoleId = "21"
                        });
                });

            modelBuilder.Entity("SmartRestaurant.Domain.Identity.Entities.LicenceKeys", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicenceKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LicenceKeys");
                });

            modelBuilder.Entity("SmartRestaurant.Domain.Identity.Entities.MyClients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LicenceStatus")
                        .HasColumnType("bit");

                    b.Property<string>("MacAdresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyClients");
                });

            modelBuilder.Entity("SmartRestaurant.Domain.Identity.Entities.Permissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ba")
                        .HasColumnType("bit");

                    b.Property<bool>("Bca")
                        .HasColumnType("bit");

                    b.Property<bool>("Bcv")
                        .HasColumnType("bit");

                    b.Property<bool>("Bl")
                        .HasColumnType("bit");

                    b.Property<bool>("Clients")
                        .HasColumnType("bit");

                    b.Property<bool>("CreancesAss")
                        .HasColumnType("bit");

                    b.Property<bool>("Fac")
                        .HasColumnType("bit");

                    b.Property<bool>("FacAvoir")
                        .HasColumnType("bit");

                    b.Property<bool>("Facpro")
                        .HasColumnType("bit");

                    b.Property<bool>("Familles")
                        .HasColumnType("bit");

                    b.Property<bool>("Fournisseurs")
                        .HasColumnType("bit");

                    b.Property<bool>("Gda")
                        .HasColumnType("bit");

                    b.Property<bool>("Gde")
                        .HasColumnType("bit");

                    b.Property<bool>("Gds")
                        .HasColumnType("bit");

                    b.Property<bool>("Gdv")
                        .HasColumnType("bit");

                    b.Property<bool>("Inventaires")
                        .HasColumnType("bit");

                    b.Property<bool>("Inviter")
                        .HasColumnType("bit");

                    b.Property<bool>("Marques")
                        .HasColumnType("bit");

                    b.Property<bool>("RegClients")
                        .HasColumnType("bit");

                    b.Property<bool>("RegFour")
                        .HasColumnType("bit");

                    b.Property<bool>("RetoursProdClient")
                        .HasColumnType("bit");

                    b.Property<bool>("RetoursProdFour")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StockAlerte")
                        .HasColumnType("bit");

                    b.Property<bool>("Stocks")
                        .HasColumnType("bit");

                    b.Property<bool>("Unites")
                        .HasColumnType("bit");

                    b.Property<bool>("Vc")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed2bc9e3-6f4d-428a-be99-106d6e728734"),
                            Ba = true,
                            Bca = true,
                            Bcv = true,
                            Bl = true,
                            Clients = true,
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
                            RegClients = true,
                            RegFour = true,
                            RetoursProdClient = true,
                            RetoursProdFour = true,
                            Role = "Super Admin",
                            StockAlerte = true,
                            Stocks = true,
                            Unites = true,
                            Vc = true
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SmartRestaurant.Domain.Identity.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartRestaurant.Domain.Identity.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartRestaurant.Domain.Identity.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartRestaurant.Domain.Identity.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartRestaurant.Domain.Identity.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("SmartRestaurant.Domain.Identity.Entities.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartRestaurant.Domain.Identity.Entities.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
