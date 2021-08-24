using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class ConvertFourDigitCodeToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodBusinesses",
                columns: table => new
                {
                    FoodBusinessId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NRC = table.Column<int>(nullable: false),
                    NIF = table.Column<int>(nullable: false),
                    NIS = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AverageRating = table.Column<double>(nullable: false),
                    NumberRatings = table.Column<int>(nullable: false),
                    HasCarParking = table.Column<bool>(nullable: false),
                    IsHandicapFriendly = table.Column<bool>(nullable: false),
                    AcceptsCreditCards = table.Column<bool>(nullable: false),
                    AcceptTakeout = table.Column<bool>(nullable: false),
                    OffersTakeout = table.Column<bool>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    FoodBusinessAdministratorId = table.Column<string>(nullable: true),
                    FoodBusinessState = table.Column<int>(nullable: false),
                    FoodBusinessCategory = table.Column<int>(nullable: false),
                    Address_StreetAddress = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_GeoPosition_Latitude = table.Column<string>(nullable: true),
                    Address_GeoPosition_Longitude = table.Column<string>(nullable: true),
                    PhoneNumber_CountryCode = table.Column<int>(nullable: true),
                    PhoneNumber_Number = table.Column<int>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    FourDigitCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBusinesses", x => x.FoodBusinessId);
                });

            migrationBuilder.CreateTable(
                name: "FoodBusinessImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    ImageBytes = table.Column<byte[]>(nullable: true),
                    ImageTitle = table.Column<string>(nullable: true),
                    IsLogo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBusinessImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodBusinessUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBusinessUsers", x => new { x.ApplicationUserId, x.FoodBusinessId });
                    table.ForeignKey(
                        name: "FK_FoodBusinessUsers_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkedDevices",
                columns: table => new
                {
                    LinkedDeviceId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    IdentifierDevice = table.Column<string>(nullable: true),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedDevices", x => x.LinkedDeviceId);
                    table.ForeignKey(
                        name: "FK_LinkedDevices_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MenuState = table.Column<int>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    ReservationName = table.Column<string>(nullable: true),
                    NumberOfDiners = table.Column<int>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    ZoneId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    ZoneTitle = table.Column<string>(nullable: true),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.ZoneId);
                    table.ForeignKey(
                        name: "FK_Zones_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    TableNumber = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    TableState = table.Column<short>(nullable: false),
                    ZoneId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_Tables_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSections",
                columns: table => new
                {
                    SubSectionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSections", x => x.SubSectionId);
                    table.ForeignKey(
                        name: "FK_SubSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodBusinesses",
                columns: new[] { "FoodBusinessId", "AcceptTakeout", "AcceptsCreditCards", "AverageRating", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessAdministratorId", "FoodBusinessCategory", "FoodBusinessState", "FourDigitCode", "HasCarParking", "IsHandicapFriendly", "LastModifiedAt", "LastModifiedBy", "NIF", "NIS", "NRC", "Name", "NumberRatings", "OffersTakeout", "Tags", "Website" },
                values: new object[] { new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), true, true, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Envie de découvrir la cuisine indienne, le restaurant Taj Mahal vous invite à le faire et voyager à travers les odeurs des épices orientales qui se dégagent de ses mets à spécialités indiennes.", null, "3cbf3570-4444-4444-8746-29b7cf568093", 0, 0, 0, true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "Taj mahal", 0, true, "", "https://restoalgerie.com/restaurant/taj-mahal-restaurant-indien/" });

            migrationBuilder.InsertData(
                table: "FoodBusinesses",
                columns: new[] { "FoodBusinessId", "AcceptTakeout", "AcceptsCreditCards", "AverageRating", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessAdministratorId", "FoodBusinessCategory", "FoodBusinessState", "FourDigitCode", "HasCarParking", "IsHandicapFriendly", "LastModifiedAt", "LastModifiedBy", "NIF", "NIS", "NRC", "Name", "NumberRatings", "OffersTakeout", "Tags", "Website" },
                values: new object[] { new Guid("66bf3570-440d-4673-8746-29b7cf568099"), true, true, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, "44bf3570-0d44-4673-8746-29b7cf568088", 0, 0, 0, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "Mcdonald's", 0, true, "", "" });

            migrationBuilder.InsertData(
                table: "FoodBusinesses",
                columns: new[] { "FoodBusinessId", "AcceptTakeout", "AcceptsCreditCards", "AverageRating", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessAdministratorId", "FoodBusinessCategory", "FoodBusinessState", "FourDigitCode", "HasCarParking", "IsHandicapFriendly", "LastModifiedAt", "LastModifiedBy", "NIF", "NIS", "NRC", "Name", "NumberRatings", "OffersTakeout", "Tags", "Website" },
                values: new object[] { new Guid("88bc7853-220f-9173-3246-afb7cf595022"), true, true, 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ETuoYe SMdsYsup qqbdspY NEeZvsaI sUcIOE sVmPkJx RZFk FOKzUkG ffAsUB XyINU fhhIB OiIfN Antdhb XHbtaO UlStFP adgVv CRTToT Mcv FAHcd YyGH. CdDIPW TtDBaI qYg wVcSK NAXHnVC xpNBE fRufEW fggeTKc Iqq dfGZPAqoc MYxnH NCLtDA qqV TNYR LbwaYqv cvIiSvl KBTMl xAxHmu dilIqO mGM kxDhvLT PsYPdCB yZE uFfvGxQp uvoeDsAaE QQjgKs CnAnhrs qNPzSuq bvZjqMfy aaEGCqc XrvE KFXnmA mEnN uGHJt WypGwSiJDmP qBDWYau SzbxbSRUb CMwhBXiYA vQCTdtiB oVkRA XpHYTFE BYFpDTVlV zafiNugG YFyiIvYhhgyzj MihfVEqk OWlRLG YAUn sXWO jbKyczKOQfhXa qziTc xxMFCM WfVzT oPdKGSK Zz CzXeis.", null, "08a1a626-7f8e-4b51-84fc-fc51b6302cca", 0, 0, 0, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "BigMama", 0, true, "", "https://bigmama.com" });

            migrationBuilder.InsertData(
                table: "FoodBusinessUsers",
                columns: new[] { "ApplicationUserId", "FoodBusinessId" },
                values: new object[,]
                {
                    { "3cbf3570-4444-4444-8746-29b7cf568093", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") },
                    { "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099") },
                    { "44bf3570-0d44-4673-8746-29b7cf568088", new Guid("66bf3570-440d-4673-8746-29b7cf568099") },
                    { "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022") },
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", new Guid("88bc7853-220f-9173-3246-afb7cf595022") },
                    { "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "MenuState", "Name" },
                values: new object[,]
                {
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8791), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Beverage  Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8814), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Dessert Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8808), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Beverage  Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8803), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Sandwiches Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8228), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Dishes Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8758), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Pizza Menu" },
                    { new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8820), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "BigMama Sandwiches Menu" },
                    { new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8832), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "BigMama Dessert Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8785), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Sandwiches Menu" },
                    { new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8826), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "BigMama Beverage  Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8797), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Dessert Menu" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "NumberOfDiners", "ReservationDate", "ReservationName" },
                values: new object[,]
                {
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596315"), new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9097), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2021, 8, 9, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9095), "ReservationName_15" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596301"), new DateTime(2021, 8, 22, 23, 2, 23, 939, DateTimeKind.Local).AddTicks(8600), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 8, 23, 2, 2, 23, 939, DateTimeKind.Local).AddTicks(8560), "ReservationName_01" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596303"), new DateTime(2021, 9, 6, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8762), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2026, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8668), "ReservationName_03" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596305"), new DateTime(2021, 8, 21, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8812), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, new DateTime(2021, 8, 22, 15, 2, 23, 939, DateTimeKind.Local).AddTicks(8809), "ReservationName_05" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596310"), new DateTime(2021, 8, 22, 23, 2, 23, 939, DateTimeKind.Local).AddTicks(8863), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2021, 8, 23, 1, 2, 23, 939, DateTimeKind.Local).AddTicks(8861), "ReservationName_10" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596312"), new DateTime(2021, 10, 12, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8881), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2025, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8878), "ReservationName_12" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596314"), new DateTime(2021, 8, 20, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9086), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, new DateTime(2021, 8, 22, 14, 2, 23, 939, DateTimeKind.Local).AddTicks(9085), "ReservationName_14" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596336"), new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9206), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 8, 22, 19, 2, 23, 939, DateTimeKind.Local).AddTicks(9204), "ReservationName_36" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596337"), new DateTime(2021, 8, 22, 20, 2, 23, 939, DateTimeKind.Local).AddTicks(9213), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 8, 22, 22, 2, 23, 939, DateTimeKind.Local).AddTicks(9211), "ReservationName_37" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596338"), new DateTime(2021, 8, 8, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9219), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2021, 8, 27, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9218), "ReservationName_38" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596339"), new DateTime(2021, 9, 11, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9227), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, new DateTime(2023, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9225), "ReservationName_39" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596340"), new DateTime(2021, 8, 22, 18, 45, 23, 939, DateTimeKind.Local).AddTicks(9234), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2031, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9232), "ReservationName_40" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596341"), new DateTime(2021, 8, 17, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9244), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, new DateTime(2021, 8, 22, 6, 2, 23, 939, DateTimeKind.Local).AddTicks(9239), "ReservationName_41" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596342"), new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9252), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 8, 15, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9250), "ReservationName_42" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596343"), new DateTime(2021, 9, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9259), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, new DateTime(2021, 10, 4, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9258), "ReservationName_43" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596300"), new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(7839), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2021, 8, 22, 23, 2, 23, 938, DateTimeKind.Local).AddTicks(1975), "ReservationName_00" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596313"), new DateTime(2021, 8, 22, 18, 38, 23, 939, DateTimeKind.Local).AddTicks(9076), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2036, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9070), "ReservationName_13" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596302"), new DateTime(2021, 8, 7, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8652), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2021, 8, 23, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8622), "ReservationName_02" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596306"), new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8823), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, new DateTime(2021, 8, 10, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8821), "ReservationName_06" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596316"), new DateTime(2021, 5, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9106), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2021, 7, 3, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9104), "ReservationName_16" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596317"), new DateTime(2021, 11, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9114), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 12, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9112), "ReservationName_17" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596327"), new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9125), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2021, 8, 22, 21, 2, 23, 939, DateTimeKind.Local).AddTicks(9122), "ReservationName_27" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596328"), new DateTime(2021, 8, 22, 22, 2, 23, 939, DateTimeKind.Local).AddTicks(9133), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2021, 8, 23, 0, 2, 23, 939, DateTimeKind.Local).AddTicks(9131), "ReservationName_28" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596329"), new DateTime(2021, 8, 8, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9141), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 8, 23, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9139), "ReservationName_29" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596330"), new DateTime(2021, 10, 16, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9150), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2024, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9148), "ReservationName_30" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596331"), new DateTime(2021, 8, 22, 18, 17, 23, 939, DateTimeKind.Local).AddTicks(9160), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2034, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9158), "ReservationName_31" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596332"), new DateTime(2021, 8, 19, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9171), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, new DateTime(2021, 8, 22, 15, 2, 23, 939, DateTimeKind.Local).AddTicks(9169), "ReservationName_32" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596333"), new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9180), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2021, 8, 12, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9178), "ReservationName_33" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596344"), new DateTime(2021, 10, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9268), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2021, 11, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9266), "ReservationName_44" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596335"), new DateTime(2021, 10, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9198), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 11, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9196), "ReservationName_35" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596311"), new DateTime(2021, 8, 8, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8872), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 8, 24, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8869), "ReservationName_11" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596309"), new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8854), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2021, 8, 22, 22, 2, 23, 939, DateTimeKind.Local).AddTicks(8852), "ReservationName_09" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596308"), new DateTime(2021, 12, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8844), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2022, 1, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8842), "ReservationName_08" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596307"), new DateTime(2021, 6, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8833), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2021, 6, 30, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8831), "ReservationName_07" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596304"), new DateTime(2021, 8, 22, 18, 38, 23, 939, DateTimeKind.Local).AddTicks(8780), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2036, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8773), "ReservationName_04" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596334"), new DateTime(2021, 6, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9189), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2021, 7, 10, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9187), "ReservationName_34" }
                });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "ZoneId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "ZoneTitle" },
                values: new object[,]
                {
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3239), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal FAMILY Zone" },
                    { new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3282), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mcdonald NORMAL Zone" },
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3275), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal OUTDOOR Zone" },
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3266), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal NORMAL Zone" },
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(2597), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal VIP Zone" },
                    { new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3287), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mcdonald OUTDOOR Zone" },
                    { new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"), new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3295), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BigMama SHARED Zone" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "TableNumber", "TableState", "ZoneId" },
                values: new object[,]
                {
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"), 4, new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(5803), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"), 6, new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6387), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"), 4, new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6448), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"), 3, new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6457), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"), 5, new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6462), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, (short)0, new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"), 3, new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6468), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, (short)0, new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2") },
                    { new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"), 6, new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6473), "64fed988-6f68-49dc-ad54-0da50ec02319", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, (short)0, new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodBusinessUsers_FoodBusinessId",
                table: "FoodBusinessUsers",
                column: "FoodBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedDevices_FoodBusinessId",
                table: "LinkedDevices",
                column: "FoodBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_FoodBusinessId",
                table: "Menus",
                column: "FoodBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FoodBusinessId",
                table: "Reservations",
                column: "FoodBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MenuId",
                table: "Sections",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSections_SectionId",
                table: "SubSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ZoneId",
                table: "Tables",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_FoodBusinessId",
                table: "Zones",
                column: "FoodBusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodBusinessImages");

            migrationBuilder.DropTable(
                name: "FoodBusinessUsers");

            migrationBuilder.DropTable(
                name: "LinkedDevices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "SubSections");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "FoodBusinesses");
        }
    }
}
