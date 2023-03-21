using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMicroService.Migrations
{
    /// <inheritdoc />
    public partial class standardata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "carTypes",
                columns: new[] { "Id", "Description", "Name", "PricePerKilometer" },
                values: new object[] { 1, "Benzine auto", "Benzine", 0.11 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarTypeId", "Description", "Name" },
                values: new object[] { 1, 1, "benzine auto volvo v90", "volvo V90" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "carTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
