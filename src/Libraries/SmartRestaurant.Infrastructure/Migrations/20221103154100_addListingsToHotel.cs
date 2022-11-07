using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addListingsToHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingId = table.Column<Guid>(nullable: false),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true),
                    WithImage = table.Column<bool>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingId);
                });

            migrationBuilder.CreateTable(
                name: "ListingDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    ListingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingDetail_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "HotelId", "WithImage", "Names_AR", "Names_EN", "Names_FR", "Names_RU", "Names_TR" },
                values: new object[,]
                {
                    { new Guid("8087b4c3-b0b0-49e5-b317-85b6b43d97cf"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" },
                    { new Guid("d9099b79-4975-48ca-894c-d92b62b037f0"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" },
                    { new Guid("518c80ef-0dc7-4f6b-b3ba-eed11f4ca9ca"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" },
                    { new Guid("8f98fbfc-ec30-4b71-81c8-f32ed6cd3e65"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" },
                    { new Guid("0bfed7fb-a809-49f2-8c96-381f569abdfd"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(8946), new DateTime(2022, 11, 3, 21, 40, 59, 666, DateTimeKind.Local).AddTicks(9709) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 21, 40, 59, 667, DateTimeKind.Local).AddTicks(9355), new DateTime(2022, 11, 4, 0, 40, 59, 667, DateTimeKind.Local).AddTicks(9328) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 19, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9386), new DateTime(2022, 11, 4, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9366) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 18, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9451), new DateTime(2027, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 17, 16, 59, 667, DateTimeKind.Local).AddTicks(9461), new DateTime(2037, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9456) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 2, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9480), new DateTime(2022, 11, 3, 13, 40, 59, 667, DateTimeKind.Local).AddTicks(9479) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9485), new DateTime(2022, 10, 22, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9491), new DateTime(2022, 9, 11, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 3, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9496), new DateTime(2023, 4, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9517), new DateTime(2022, 11, 3, 20, 40, 59, 667, DateTimeKind.Local).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 21, 40, 59, 667, DateTimeKind.Local).AddTicks(9522), new DateTime(2022, 11, 3, 23, 40, 59, 667, DateTimeKind.Local).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9527), new DateTime(2022, 11, 5, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9525) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 24, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9532), new DateTime(2026, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 17, 16, 59, 667, DateTimeKind.Local).AddTicks(9537), new DateTime(2037, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 1, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9545), new DateTime(2022, 11, 3, 12, 40, 59, 667, DateTimeKind.Local).AddTicks(9544) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9551), new DateTime(2022, 10, 21, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9549) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9556), new DateTime(2022, 9, 14, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 2, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9561), new DateTime(2023, 3, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9566), new DateTime(2022, 11, 3, 19, 40, 59, 667, DateTimeKind.Local).AddTicks(9565) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 20, 40, 59, 667, DateTimeKind.Local).AddTicks(9571), new DateTime(2022, 11, 3, 22, 40, 59, 667, DateTimeKind.Local).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9575), new DateTime(2022, 11, 4, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9574) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 28, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9580), new DateTime(2025, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 16, 55, 59, 667, DateTimeKind.Local).AddTicks(9586), new DateTime(2035, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 31, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9591), new DateTime(2022, 11, 3, 13, 40, 59, 667, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9595), new DateTime(2022, 10, 24, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9602), new DateTime(2022, 9, 21, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9607), new DateTime(2023, 2, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9612), new DateTime(2022, 11, 3, 17, 40, 59, 667, DateTimeKind.Local).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 18, 40, 59, 667, DateTimeKind.Local).AddTicks(9616), new DateTime(2022, 11, 3, 20, 40, 59, 667, DateTimeKind.Local).AddTicks(9615) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9621), new DateTime(2022, 11, 8, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 23, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9627), new DateTime(2024, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9625) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 3, 17, 23, 59, 667, DateTimeKind.Local).AddTicks(9633), new DateTime(2032, 11, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9631) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 29, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9638), new DateTime(2022, 11, 3, 4, 40, 59, 667, DateTimeKind.Local).AddTicks(9636) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9643), new DateTime(2022, 10, 27, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9642) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9648), new DateTime(2022, 12, 16, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9646) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9654), new DateTime(2023, 2, 3, 16, 40, 59, 667, DateTimeKind.Local).AddTicks(9652) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 3, 16, 40, 59, 668, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.InsertData(
                table: "hotelUsers",
                columns: new[] { "ApplicationUserId", "HotelId" },
                values: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") });

            migrationBuilder.InsertData(
                table: "ListingDetail",
                columns: new[] { "Id", "ListingId", "PictureUrl", "Names_AR", "Names_EN", "Names_FR", "Names_RU", "Names_TR" },
                values: new object[] { new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new Guid("8087b4c3-b0b0-49e5-b317-85b6b43d97cf"), null, "بيكانتو", "Picanto", "Picanto", "прокат автомобилей", "Picanto" });

            migrationBuilder.InsertData(
                table: "ListingDetail",
                columns: new[] { "Id", "ListingId", "PictureUrl", "Names_AR", "Names_EN", "Names_FR", "Names_RU", "Names_TR" },
                values: new object[] { new Guid("0bfed7fb-a809-49f2-8c96-381f569abdfd"), new Guid("8087b4c3-b0b0-49e5-b317-85b6b43d97cf"), null, "بولو", "Polo", "Polo", "прокат автомобилей", "Polo" });

            migrationBuilder.CreateIndex(
                name: "IX_ListingDetail_ListingId",
                table: "ListingDetail",
                column: "ListingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingDetail");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DeleteData(
                table: "hotelUsers",
                keyColumns: new[] { "ApplicationUserId", "HotelId" },
                keyValues: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(7088), new DateTime(2022, 10, 10, 3, 32, 21, 39, DateTimeKind.Local).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 3, 32, 21, 43, DateTimeKind.Local).AddTicks(8731), new DateTime(2022, 10, 10, 6, 32, 21, 43, DateTimeKind.Local).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(8858), new DateTime(2022, 10, 10, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9085), new DateTime(2027, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(8879) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 23, 8, 21, 43, DateTimeKind.Local).AddTicks(9129), new DateTime(2037, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 8, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9197), new DateTime(2022, 10, 9, 19, 32, 21, 43, DateTimeKind.Local).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9219), new DateTime(2022, 9, 27, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9242), new DateTime(2022, 8, 17, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 2, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9263), new DateTime(2023, 3, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9257) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9284), new DateTime(2022, 10, 10, 2, 32, 21, 43, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 3, 32, 21, 43, DateTimeKind.Local).AddTicks(9305), new DateTime(2022, 10, 10, 5, 32, 21, 43, DateTimeKind.Local).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9330), new DateTime(2022, 10, 11, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 29, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9350), new DateTime(2026, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9344) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 23, 8, 21, 43, DateTimeKind.Local).AddTicks(9370), new DateTime(2037, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 7, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9391), new DateTime(2022, 10, 9, 18, 32, 21, 43, DateTimeKind.Local).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9410), new DateTime(2022, 9, 26, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9406) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9432), new DateTime(2022, 8, 20, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9457), new DateTime(2023, 2, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9479), new DateTime(2022, 10, 10, 1, 32, 21, 43, DateTimeKind.Local).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 2, 32, 21, 43, DateTimeKind.Local).AddTicks(9499), new DateTime(2022, 10, 10, 4, 32, 21, 43, DateTimeKind.Local).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9519), new DateTime(2022, 10, 10, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 3, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9540), new DateTime(2025, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 47, 21, 43, DateTimeKind.Local).AddTicks(9560), new DateTime(2035, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 6, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9579), new DateTime(2022, 10, 9, 19, 32, 21, 43, DateTimeKind.Local).AddTicks(9574) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9598), new DateTime(2022, 9, 29, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9618), new DateTime(2022, 8, 27, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9640), new DateTime(2023, 1, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9660), new DateTime(2022, 10, 9, 23, 32, 21, 43, DateTimeKind.Local).AddTicks(9655) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 0, 32, 21, 43, DateTimeKind.Local).AddTicks(9680), new DateTime(2022, 10, 10, 2, 32, 21, 43, DateTimeKind.Local).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9700), new DateTime(2022, 10, 14, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9694) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 29, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9724), new DateTime(2024, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 23, 15, 21, 43, DateTimeKind.Local).AddTicks(9745), new DateTime(2032, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9766), new DateTime(2022, 10, 9, 10, 32, 21, 43, DateTimeKind.Local).AddTicks(9761) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9785), new DateTime(2022, 10, 2, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9806), new DateTime(2022, 11, 21, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9801) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9827), new DateTime(2023, 1, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1923));
        }
    }
}
