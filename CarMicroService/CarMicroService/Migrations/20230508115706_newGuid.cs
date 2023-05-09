using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMicroService.Migrations
{
    /// <inheritdoc />
    public partial class newGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CarTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "CarTypeId",
                table: "CarTypes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarTypeId",
                table: "Cars",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Cars",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes",
                column: "CarTypeId");

            migrationBuilder.InsertData(
                table: "CarTypes",
                columns: new[] { "CarTypeId", "Description", "Name", "PricePerKilometer" },
                values: new object[] { new Guid("7d3ec957-3190-460b-bfb3-4f26b0e6a165"), "Benzine auto", "Benzine", 0.11 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarTypeId", "Description", "Name" },
                values: new object[] { new Guid("f0017fd5-48d0-4405-b2b8-42b0dbb90550"), new Guid("7d3ec957-3190-460b-bfb3-4f26b0e6a165"), "benzine auto volvo v90", "volvo V90" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarTypes",
                principalColumn: "CarTypeId",
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

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f0017fd5-48d0-4405-b2b8-42b0dbb90550"));

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "CarTypeId",
                keyColumnType: "char(36)",
                keyValue: new Guid("7d3ec957-3190-460b-bfb3-4f26b0e6a165"));

            migrationBuilder.DropColumn(
                name: "CarTypeId",
                table: "CarTypes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CarTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "CarTypeId",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CarTypes",
                columns: new[] { "Id", "Description", "Name", "PricePerKilometer" },
                values: new object[] { 1, "Benzine auto", "Benzine", 0.11 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarTypeId", "Description", "Name" },
                values: new object[] { 1, 1, "benzine auto volvo v90", "volvo V90" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
