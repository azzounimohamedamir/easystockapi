using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updatedListingDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetail_Listings_ListingId",
                table: "ListingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingDetail",
                table: "ListingDetail");

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: new Guid("0bfed7fb-a809-49f2-8c96-381f569abdfd"));

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: new Guid("518c80ef-0dc7-4f6b-b3ba-eed11f4ca9ca"));

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: new Guid("8f98fbfc-ec30-4b71-81c8-f32ed6cd3e65"));

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: new Guid("d9099b79-4975-48ca-894c-d92b62b037f0"));

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "ListingDetail");

            migrationBuilder.RenameTable(
                name: "ListingDetail",
                newName: "ListingDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ListingDetail_ListingId",
                table: "ListingDetails",
                newName: "IX_ListingDetails_ListingId");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "ListingDetails",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingDetails",
                table: "ListingDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: new Guid("8087b4c3-b0b0-49e5-b317-85b6b43d97cf"),
                column: "Names_FR",
                value: "Locations de voitures");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetails_Listings_ListingId",
                table: "ListingDetails",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "ListingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetails_Listings_ListingId",
                table: "ListingDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingDetails",
                table: "ListingDetails");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ListingDetails");

            migrationBuilder.RenameTable(
                name: "ListingDetails",
                newName: "ListingDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ListingDetails_ListingId",
                table: "ListingDetail",
                newName: "IX_ListingDetail_ListingId");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "ListingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingDetail",
                table: "ListingDetail",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: new Guid("8087b4c3-b0b0-49e5-b317-85b6b43d97cf"),
                column: "Names_FR",
                value: "locations de voitures");

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "HotelId", "WithImage", "Names_AR", "Names_EN", "Names_FR", "Names_RU", "Names_TR" },
                values: new object[,]
                {
                    { new Guid("d9099b79-4975-48ca-894c-d92b62b037f0"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" },
                    { new Guid("518c80ef-0dc7-4f6b-b3ba-eed11f4ca9ca"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" },
                    { new Guid("8f98fbfc-ec30-4b71-81c8-f32ed6cd3e65"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" },
                    { new Guid("0bfed7fb-a809-49f2-8c96-381f569abdfd"), new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), false, "تأجير السيارات", "Car rentals", "locations de voitures", "прокат автомобилей", "Araba kiralama" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetail_Listings_ListingId",
                table: "ListingDetail",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "ListingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
