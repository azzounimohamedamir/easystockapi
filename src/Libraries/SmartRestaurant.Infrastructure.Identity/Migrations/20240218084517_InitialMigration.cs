using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsShowPhoneNumberInOdoo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "88f0dec2-5364-4881-4817-1f2a135a8641", "SuperAdmin", "SUPERADMIN" },
                    { "18", "270b4553-f9b8-48e0-b244-af2ce4bc5ca9", "HotelServiceTechnique", "HOTELSERVICETECHNIQUE" },
                    { "17", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelClient", "HOTELCLIENT" },
                    { "16", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelServiceAdmin", "HOTELSERVICEADMIN" },
                    { "15", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelReceptionist", "HOTELRECEPTIONIST" },
                    { "14", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelManager", "HOTELMANAGER" },
                    { "13", "edpc7115-422c-487d-15b0-58cfa8e66a98", "Organization", "ORGANIZATION" },
                    { "12", "educ7115-422c-487d-25b0-58cfa8e66a98", "Anounymous", "ANOUNYMOUS" },
                    { "11", "edcc7115-422c-487d-95b0-58cfa8e66a98", "Diner", "DINER" },
                    { "19", "2622be83-085c-4339-ae68-ffa9d5cd2fa8", "HouseKeeping", "HOUSEKEEPING" },
                    { "8", "elcc7115-422c-487d-95b0-58cfa8e66a96", "Chef", "CHEF" },
                    { "9", "encc7115-422c-487d-95b0-58cfa8e66a95", "Cashier", "CASHIER" },
                    { "7", "emcb7115-422c-487d-95c0-58cfa8m66a94", "FoodBusinessOwner", "FOODBUSINESSOWNER" },
                    { "6", "emcc7115-422c-487d-95b0-58cfa8e66a94", "FoodBusinessManager", "FOODBUSINESSMANAGER" },
                    { "5", "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d2", "FoodBusinessAdministrator", "FOODBUSINESSADMINISTRATOR" },
                    { "4", "emtc7115-422c-487d-85b0-58cfa8e66a94", "Photograph", "PHOTOGRAPH" },
                    { "3", "emrc7115-422c-487d-75b0-58cfa8e66a94", "SalesMan", "SALESMAN" },
                    { "2", "emec7115-422c-487d-65b0-58cfa8e66a94", "SupportAgent", "SUPPORTAGENT" },
                    { "10", "ekcc7115-422c-487d-95b0-58cfa8e66a97", "Waiter", "WAITER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "IsShowPhoneNumberInOdoo", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", 0, "84aad3b1-d291-4cdb-a1dd-93058077ad71", "manager@sonatrach.com", true, null, true, false, false, null, "MANAGER@SONATRACH.COM", "MANAGER@SONATRACH.COM", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "f7782a70-2efd-44a9-a958-3d33d480ca8e", false, "manager@sonatrach.com" },
                    { "ba89dc5f-dfd1-4c87-9372-233c611cc756", 0, "c89a903b-304c-4096-aae7-5c6c720a23dd", "manager@cevital.com", true, null, true, false, false, null, "MANAGER@CEVITAL.COM", "MANAGER@CEVITAL.COM", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "9950c1bf-3b42-4a6a-a7eb-3404aa046216", false, "manager@cevital.com" },
                    { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", 0, "258ed555-fe6f-41ea-8c70-900e3199d83e", "ClientHotel@gmail.com", true, null, true, false, false, null, "CLIENTHOTEL@GMAIL.COM", "CLIENTHOTEL@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "195f37a1-e508-4e98-aea3-bd15cf3fc685", false, "ClientHotel@gmail.com" },
                    { "83e72357-25b8-4e2a-8728-3e25365608e2", 0, "7040d623-69ea-4f51-baa8-a80b2cb292e7", "HotelReceptionist@gmail.com", true, null, true, false, false, null, "HOTELRECEPTIONIST@GMAIL.COM", "HOTELRECEPTIONIST@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "03e0d5d9-8785-454b-bdec-0730159e007a", false, "HotelReceptionist@gmail.com" },
                    { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", 0, "a1b46a95-8bbd-46cf-8dba-00d8b0be14e9", "HotelServiceAdmin@gmail.com", true, null, true, false, false, null, "HOTELSERVICEADMIN@GMAIL.COM", "HOTELSERVICEADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "1671ae0d-fae0-4fe5-8413-7b704b3b78e8", false, "HotelServiceAdmin@gmail.com" },
                    { "6b14cd00-59f0-4422-bfce-07c080829987", 0, "6c7b4408-3b11-4440-b143-d23c3004c07c", "Diner_02@SmartRestaurant.io", true, null, true, false, false, null, "DINER_02@SMARTRESTAURANT.IO", "DINER_02@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEJFZbbuBIpvoyXKwrceuNsU4cXZ18LLAl8g7s48Pye4EAEXwA2hswtnLMhMS9Q7Cjw ==", null, false, "b5d3366f-0acb-46a2-94c8-8fb0edf87b68", false, "Diner_02@SmartRestaurant.io" },
                    { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", 0, "b9a3be64-47e7-4fec-899d-925c19b22752", "HotelManager@gmail.com", true, null, true, false, false, null, "HOTELMANAGER@GMAIL.COM", "HOTELMANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "e6fb777d-5bb3-4b31-aee4-86950dc932df", false, "HotelManager@gmail.com" },
                    { "5a84cd00-59f0-4b22-bfce-07c080829118", 0, "f0fc3398-fc93-4112-9082-e8effb4bfd88", "Diner_01@SmartRestaurant.io", true, null, true, false, false, null, "DINER_01@SMARTRESTAURANT.IO", "DINER_01@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEJFZbbuBIpvoyXKwrceuNsU4cXZ18LLAl8g7s48Pye4EAEXwA2hswtnLMhMS9Q7Cjw ==", null, false, "7eaa18b4-8daf-485e-aabf-50b4c7f5ac13", false, "Diner_01@SmartRestaurant.io" },
                    { "44bf3570-0d44-4673-8746-29b7cf568088", 0, "1d9d3f82-8340-4371-9b9a-5e2c59b13364", "McdonaldFoodAdmin@SmartRestaurant.io", true, null, true, false, false, null, "MCDONALDFOODADMIN@SMARTRESTAURANT.IO", "MCDONALDFOODADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "7b90ad26-43c0-4fa7-a4e9-a59418e97f14", false, "McdonaldFoodAdmin@SmartRestaurant.io" },
                    { "b2207466-ceda-4b50-b18d-0ac4f4102caa", 0, "515551f3-ae7b-426d-ad65-c1b6e2d0393e", "McdonaldFoodBusinessManager@SmartRestaurant.io", true, null, true, false, false, null, "MCDONALDFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "MCDONALDFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "1e71a0be-ab6b-4d2b-9732-3d1f7c1c0938", false, "McdonaldFoodBusinessManager@SmartRestaurant.io" },
                    { "a1997466-cedc-4850-b18d-0ac4f4102cff", 0, "1df356e7-0f86-469a-b665-f40d0f9eaece", "TajMhalFoodBusinessManager@SmartRestaurant.io", true, null, true, false, false, null, "TAJMHALFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "TAJMHALFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "398cdb62-ad32-4559-a614-ddda05c24fa2", false, "TajMhalFoodBusinessManager@SmartRestaurant.io" },
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", 0, "089a1be9-5795-4e89-94d9-628ded8387b5", "BigMamaFoodBusinessAdministrator@SmartRestaurant.io", true, null, true, false, false, null, "BIGMAMAFOODBUSINESSADMINISTRATOR@SMARTRESTAURANT.IO", "BIGMAMAFOODBUSINESSADMINISTRATOR@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "a7e6c763-ea53-4bc4-a1e0-3068b7699fc8", false, "BigMamaFoodBusinessAdministrator@SmartRestaurant.io" },
                    { "3cbf3570-4444-4444-8746-29b7cf568093", 0, "4bd40bb7-9cdd-4e46-9227-a413ed5659ac", "FoodAdmin@SmartRestaurant.io", true, null, true, false, false, null, "FOODADMIN@SMARTRESTAURANT.IO", "FOODADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "88c545c3-fec2-43d5-9233-04b6bd282698", false, "FoodAdmin@SmartRestaurant.io" },
                    { "d466ef00-61f1-4e77-801a-b516f0f12323", 0, "33ec0018-4ad6-494a-8c13-b08aed2275e3", "Waiter@SmartRestaurant.io", true, null, true, false, false, null, "WAITER@SMARTRESTAURANT.IO", "WAITER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "b7efea43-20ea-48c6-89e5-62f2584ab7d6", false, "Waiter@SmartRestaurant.io" },
                    { "d466ef00-61f1-4e77-801a-b016f0f12323", 0, "8f606bc1-28ac-457b-b9a3-2659d4365d5e", "SupportAgent@SmartRestaurant.io", true, null, true, false, false, null, "SUPPORTAGENT@SMARTRESTAURANT.IO", "SUPPORTAGENT@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "61ff6f6d-c2b8-46a1-941a-18fd82789d9e", false, "SupportAgent@SmartRestaurant.io" },
                    { "3cbf3570-0d44-4673-8746-29b7cf568093", 0, "7a012b13-c40b-4df8-94ab-5bc8f649321f", "SuperAdmin@SmartRestaurant.io", true, null, true, false, false, null, "SUPERADMIN@SMARTRESTAURANT.IO", "SUPERADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEAzFpmzMtMiw0wHV6b0aUzFLF9Pw7B2u+DswRHttAU2nH22NHBsc/hSSvKUqmRWGZA==", null, false, "3631400b-0c9a-4a6b-8d2d-aa870fb961d6", false, "SuperAdmin@SmartRestaurant.io" },
                    { "acd04fc6-99da-436f-a011-191b7e92aa23", 0, "c5367e56-8326-4ce2-b495-50556116e7f2", "HotelServiceTechnique@gmail.com", true, null, true, false, false, null, "HOTELSERVICETECHNIQUE@GMAIL.COM", "HOTELSERVICETECHNIQUE@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "bb9069d6-e12f-4f32-b256-c5e8e81438dd", false, "HotelServiceTechnique@gmail.com" },
                    { "64fed988-6f68-49dc-ad54-0da50ec02319", 0, "933e679c-97b0-4469-931d-c38475e0b772", "BigMamaSalimFoodBusinessManager@SmartRestaurant.io", true, null, true, false, false, null, "BIGMAMASALIMFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "BIGMAMASALIMFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEO+ouwzSOa+AsCNZrVEhO6Su9q/fX/Q9c9havEvhs5QtXWA6tRdfmqOlemUQphqDnA==", null, false, "55c60785-8dac-474a-a214-efabb2462f94", false, "BigMamaSalimFoodBusinessManager@SmartRestaurant.io" },
                    { "7d33ae49-68a8-4c10-bc57-b09da6f9f016", 0, "36585e6a-b14a-4042-a6ce-7a5d1cc75979", "HotelMaid@gmail.com", true, null, true, false, false, null, "HOTELMAID@GMAIL.COM", "HOTELMAID@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "cbed85f8-dbcd-459b-9a48-be46ec964c36", false, "HotelMaid@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "3cbf3570-0d44-4673-8746-29b7cf568093", "1" },
                    { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", "17" },
                    { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", "16" },
                    { "83e72357-25b8-4e2a-8728-3e25365608e2", "15" },
                    { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", "14" },
                    { "ba89dc5f-dfd1-4c87-9372-233c611cc756", "13" },
                    { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", "13" },
                    { "6b14cd00-59f0-4422-bfce-07c080829987", "11" },
                    { "acd04fc6-99da-436f-a011-191b7e92aa23", "18" },
                    { "5a84cd00-59f0-4b22-bfce-07c080829118", "11" },
                    { "b2207466-ceda-4b50-b18d-0ac4f4102caa", "6" },
                    { "a1997466-cedc-4850-b18d-0ac4f4102cff", "6" },
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", "5" },
                    { "44bf3570-0d44-4673-8746-29b7cf568088", "5" },
                    { "3cbf3570-4444-4444-8746-29b7cf568093", "5" },
                    { "d466ef00-61f1-4e77-801a-b516f0f12323", "10" },
                    { "d466ef00-61f1-4e77-801a-b016f0f12323", "2" },
                    { "64fed988-6f68-49dc-ad54-0da50ec02319", "6" },
                    { "7d33ae49-68a8-4c10-bc57-b09da6f9f016", "19" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
