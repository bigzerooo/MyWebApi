using Microsoft.EntityFrameworkCore.Migrations;

namespace V3._0.Migrations
{
    public partial class RelationTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarId",
                table: "CarHires",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_ClientId",
                table: "CarHires",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Cars_CarId",
                table: "CarHires",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Clients_ClientId",
                table: "CarHires",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Cars_CarId",
                table: "CarHires");

            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Clients_ClientId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_CarId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_ClientId",
                table: "CarHires");
        }
    }
}
