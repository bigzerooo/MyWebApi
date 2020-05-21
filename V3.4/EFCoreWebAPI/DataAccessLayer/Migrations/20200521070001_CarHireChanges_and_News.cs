using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CarHireChanges_and_News : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_CarStates_CarStateId",
                table: "CarHires");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CarHires",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CarStateId",
                table: "CarHires",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedEndDate",
                table: "CarHires",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedPrice",
                table: "CarHires",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Returned",
                table: "CarHires",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_CarStates_CarStateId",
                table: "CarHires",
                column: "CarStateId",
                principalTable: "CarStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_CarStates_CarStateId",
                table: "CarHires");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropColumn(
                name: "ExpectedEndDate",
                table: "CarHires");

            migrationBuilder.DropColumn(
                name: "ExpectedPrice",
                table: "CarHires");

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "CarHires");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CarHires",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarStateId",
                table: "CarHires",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_CarStates_CarStateId",
                table: "CarHires",
                column: "CarStateId",
                principalTable: "CarStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
