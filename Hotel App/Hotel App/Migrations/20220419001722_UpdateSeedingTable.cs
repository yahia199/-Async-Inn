using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_App.Migrations
{
    public partial class UpdateSeedingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Country", "Phone", "State", "StreetAdress" },
                values: new object[] { "Amman", "Jordan", 77, "Amman", "University str." });

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Country", "Phone", "State", "StreetAdress" },
                values: new object[] { "Irbid", "Jordan", 78, "Irbid", "University str." });

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Country", "Phone", "State", "StreetAdress" },
                values: new object[] { "Zarqa", "Jordan", 79, "Amman", "University str." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Country", "Phone", "State", "StreetAdress" },
                values: new object[] { null, null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Country", "Phone", "State", "StreetAdress" },
                values: new object[] { null, null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Country", "Phone", "State", "StreetAdress" },
                values: new object[] { null, null, 0, null, null });
        }
    }
}
