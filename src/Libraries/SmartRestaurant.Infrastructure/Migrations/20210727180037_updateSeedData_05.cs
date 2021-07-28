using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodBusinesses",
                keyColumn: "FoodBusinessId",
                keyValue: new Guid("3cbf3570-4444-4673-8746-29b7cf568093"),
                columns: new[] { "Description", "IsHandicapFriendly", "Website" },
                values: new object[] { "Envie de découvrir la cuisine indienne, le restaurant Taj Mahal vous invite à le faire et voyager à travers les odeurs des épices orientales qui se dégagent de ses mets à spécialités indiennes.", false, "https://restoalgerie.com/restaurant/taj-mahal-restaurant-indien/" });

            migrationBuilder.InsertData(
                table: "FoodBusinesses",
                columns: new[] { "FoodBusinessId", "AcceptTakeout", "AcceptsCreditCards", "AverageRating", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessAdministratorId", "FoodBusinessCategory", "FoodBusinessState", "HasCarParking", "IsHandicapFriendly", "LastModifiedAt", "LastModifiedBy", "NIF", "NIS", "NRC", "Name", "NumberRatings", "OffersTakeout", "Tags", "Website" },
                values: new object[] { new Guid("88bc7853-220f-9173-3246-afb7cf595022"), true, true, 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ETuoYeSMdsYsupqqbdspYNEeZvsaIsUcIOEsVmPkJxRZFkFOKzUkGffAsUBXyINUfhhIBOiIfNAntdhbXHbtaOUlStFPadgVvCRTToTMcvFAHcdYyGHCdDIPWTtDBaIqYgwVcSKNAXHnVCxpNBEfRufEWfggeTKcIqqdfGZPAqocMYxnHNCLtDAqqVTNYRLbwaYqvcvIiSvlKBTMlxAxHmudilIqOmGMkxDhvLTPsYPdCByZEuFfvGxQpuvoeDsAaEQQjgKsCnAnhrsqNPzSuqbvZjqMfyaaEGCqcXrvEKFXnmAmEnNuGHJtWypGwSiJDmPqBDWYauSzbxbSRUbCMwhBXiYAvQCTdtiBoVkRAXpHYTFEBYFpDTVlVzafiNugGYFyiIvYhhgyzjMihfVEqkOWlRLGYAUnsXWOjbKyczKOQfhXaqziTcxxMFCMWfVzToPdKGSKZzCzXeisjsHKGUgtwjBACUhPDjcnwmbmOodlJqfyYLsa", null, "08a1a626-7f8e-4b51-84fc-fc51b6302cca", 0, 0, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "BigMama", 0, true, "", "https://bigmama.com" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(7483), new DateTime(2021, 7, 28, 1, 0, 36, 723, DateTimeKind.Local).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 0, 36, 728, DateTimeKind.Local).AddTicks(8517), new DateTime(2021, 7, 28, 4, 0, 36, 728, DateTimeKind.Local).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8599), new DateTime(2021, 7, 28, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8694), new DateTime(2026, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8617) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 36, 36, 728, DateTimeKind.Local).AddTicks(8727), new DateTime(2036, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8770), new DateTime(2021, 7, 27, 17, 0, 36, 728, DateTimeKind.Local).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8791), new DateTime(2021, 7, 15, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8786) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8959), new DateTime(2021, 6, 4, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8980), new DateTime(2021, 12, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8997), new DateTime(2021, 7, 28, 0, 0, 36, 728, DateTimeKind.Local).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 0, 36, 728, DateTimeKind.Local).AddTicks(9017), new DateTime(2021, 7, 28, 3, 0, 36, 728, DateTimeKind.Local).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9036), new DateTime(2021, 7, 29, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9055), new DateTime(2025, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9048) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 36, 36, 728, DateTimeKind.Local).AddTicks(9076), new DateTime(2036, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9069) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 25, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9094), new DateTime(2021, 7, 27, 16, 0, 36, 728, DateTimeKind.Local).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 7, 14, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9105) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9129), new DateTime(2021, 6, 7, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9123) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9147), new DateTime(2021, 11, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9165), new DateTime(2021, 7, 27, 23, 0, 36, 728, DateTimeKind.Local).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 0, 0, 36, 728, DateTimeKind.Local).AddTicks(9181), new DateTime(2021, 7, 28, 2, 0, 36, 728, DateTimeKind.Local).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9203), new DateTime(2021, 7, 28, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9193) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 20, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9226), new DateTime(2024, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 15, 36, 728, DateTimeKind.Local).AddTicks(9244), new DateTime(2034, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9260), new DateTime(2021, 7, 27, 17, 0, 36, 728, DateTimeKind.Local).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9278), new DateTime(2021, 7, 17, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9295), new DateTime(2021, 6, 14, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9312), new DateTime(2021, 10, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9331), new DateTime(2021, 7, 27, 21, 0, 36, 728, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 22, 0, 36, 728, DateTimeKind.Local).AddTicks(9349), new DateTime(2021, 7, 28, 0, 0, 36, 728, DateTimeKind.Local).AddTicks(9343) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9365), new DateTime(2021, 8, 1, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 16, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9387), new DateTime(2023, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 43, 36, 728, DateTimeKind.Local).AddTicks(9406), new DateTime(2031, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9423), new DateTime(2021, 7, 27, 8, 0, 36, 728, DateTimeKind.Local).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9440), new DateTime(2021, 7, 20, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9457), new DateTime(2021, 9, 8, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9452) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9475), new DateTime(2021, 10, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.InsertData(
                table: "FoodBusinessUsers",
                columns: new[] { "ApplicationUserId", "FoodBusinessId" },
                values: new object[,]
                {
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", new Guid("88bc7853-220f-9173-3246-afb7cf595022") },
                    { "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022") }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "MenuState", "Name" },
                values: new object[,]
                {
                    { new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"), new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(837), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Sandwiches Menu" },
                    { new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"), new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(958), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Beverage  Menu" },
                    { new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"), new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(973), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Dessert Menu" }
                });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "ZoneId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "ZoneTitle" },
                values: new object[] { new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"), new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3644), "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BigMama SHARED Zone" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "TableNumber", "TableState", "ZoneId" },
                values: new object[] { new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"), 6, new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7570), "64fed988-6f68-49dc-ad54-0da50ec02319", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, (short)0, new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", new Guid("88bc7853-220f-9173-3246-afb7cf595022") });

            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "64fed988-6f68-49dc-ad54-0da50ec02319", new Guid("88bc7853-220f-9173-3246-afb7cf595022") });

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"));

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"));

            migrationBuilder.DeleteData(
                table: "FoodBusinesses",
                keyColumn: "FoodBusinessId",
                keyValue: new Guid("88bc7853-220f-9173-3246-afb7cf595022"));

            migrationBuilder.UpdateData(
                table: "FoodBusinesses",
                keyColumn: "FoodBusinessId",
                keyValue: new Guid("3cbf3570-4444-4673-8746-29b7cf568093"),
                columns: new[] { "Description", "IsHandicapFriendly", "Website" },
                values: new object[] { "", true, "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(5647), new DateTime(2021, 7, 24, 23, 12, 32, 185, DateTimeKind.Local).AddTicks(6104) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 23, 12, 32, 197, DateTimeKind.Local).AddTicks(6927), new DateTime(2021, 7, 25, 2, 12, 32, 197, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 9, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7047), new DateTime(2021, 7, 25, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 8, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7181), new DateTime(2026, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 48, 32, 197, DateTimeKind.Local).AddTicks(7232), new DateTime(2036, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7304), new DateTime(2021, 7, 24, 15, 12, 32, 197, DateTimeKind.Local).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7337), new DateTime(2021, 7, 12, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7377), new DateTime(2021, 6, 1, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7412), new DateTime(2021, 12, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7453), new DateTime(2021, 7, 24, 22, 12, 32, 197, DateTimeKind.Local).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 23, 12, 32, 197, DateTimeKind.Local).AddTicks(7485), new DateTime(2021, 7, 25, 1, 12, 32, 197, DateTimeKind.Local).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7517), new DateTime(2021, 7, 26, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7506) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7551), new DateTime(2025, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7539) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 48, 32, 197, DateTimeKind.Local).AddTicks(7586), new DateTime(2036, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7619), new DateTime(2021, 7, 24, 14, 12, 32, 197, DateTimeKind.Local).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7650), new DateTime(2021, 7, 11, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7686), new DateTime(2021, 6, 4, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7723), new DateTime(2021, 11, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7757), new DateTime(2021, 7, 24, 21, 12, 32, 197, DateTimeKind.Local).AddTicks(7746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 22, 12, 32, 197, DateTimeKind.Local).AddTicks(7792), new DateTime(2021, 7, 25, 0, 12, 32, 197, DateTimeKind.Local).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7825), new DateTime(2021, 7, 25, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7862), new DateTime(2024, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 27, 32, 197, DateTimeKind.Local).AddTicks(7896), new DateTime(2034, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 21, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7931), new DateTime(2021, 7, 24, 15, 12, 32, 197, DateTimeKind.Local).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7964), new DateTime(2021, 7, 14, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8000), new DateTime(2021, 6, 11, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7987) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8043), new DateTime(2021, 10, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8078), new DateTime(2021, 7, 24, 19, 12, 32, 197, DateTimeKind.Local).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 20, 12, 32, 197, DateTimeKind.Local).AddTicks(8112), new DateTime(2021, 7, 24, 22, 12, 32, 197, DateTimeKind.Local).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8148), new DateTime(2021, 7, 29, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8135) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8182), new DateTime(2023, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 55, 32, 197, DateTimeKind.Local).AddTicks(8249), new DateTime(2031, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 19, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8282), new DateTime(2021, 7, 24, 6, 12, 32, 197, DateTimeKind.Local).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8317), new DateTime(2021, 7, 17, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8352), new DateTime(2021, 9, 5, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8389), new DateTime(2021, 10, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(4027));
        }
    }
}
