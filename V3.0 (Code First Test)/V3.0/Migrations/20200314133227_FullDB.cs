using Microsoft.EntityFrameworkCore.Migrations;

namespace V3._0.Migrations
{
    public partial class FullDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarStates",
                columns: table => new
                {
                    State = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarStates", x => x.State);
                });

            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Type);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TypeOfClient",
                table: "Clients",
                column: "TypeOfClient");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Type",
                table: "Cars",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarState",
                table: "CarHires",
                column: "CarState");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_CarStates_CarState",
                table: "CarHires",
                column: "CarState",
                principalTable: "CarStates",
                principalColumn: "State",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_Type",
                table: "Cars",
                column: "Type",
                principalTable: "CarTypes",
                principalColumn: "Type",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientTypes_TypeOfClient",
                table: "Clients",
                column: "TypeOfClient",
                principalTable: "ClientTypes",
                principalColumn: "Type",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_CarStates_CarState",
                table: "CarHires");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_Type",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientTypes_TypeOfClient",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "CarStates");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TypeOfClient",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cars_Type",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_CarState",
                table: "CarHires");
        }
    }
}
