using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_App.Migrations
{
    public partial class SeedingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Amenity 1" },
                    { 2, "Amenity 2" },
                    { 3, "Amenity 3" }
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "State", "StreetAdress" },
                values: new object[,]
                {
                    { 1, null, null, "Hotel 1", 0, null, null },
                    { 2, null, null, "Hotel 2", 0, null, null },
                    { 3, null, null, "Hotel 3", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Room 1" },
                    { 2, 2, "Room 2" },
                    { 3, 3, "Room 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
