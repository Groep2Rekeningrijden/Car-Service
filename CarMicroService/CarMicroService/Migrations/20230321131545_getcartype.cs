using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMicroService.Migrations
{
    /// <inheritdoc />
    public partial class getcartype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_carTypes_CarTypeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carTypes",
                table: "carTypes");

            migrationBuilder.RenameTable(
                name: "carTypes",
                newName: "CarTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes");

            migrationBuilder.RenameTable(
                name: "CarTypes",
                newName: "carTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carTypes",
                table: "carTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_carTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "carTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
