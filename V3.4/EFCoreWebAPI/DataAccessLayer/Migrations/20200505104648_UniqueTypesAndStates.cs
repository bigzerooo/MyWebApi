using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UniqueTypesAndStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_Type",
                table: "ClientTypes",
                column: "Type",
                unique: true,
                filter: "[Type] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarTypes_Type",
                table: "CarTypes",
                column: "Type",
                unique: true,
                filter: "[Type] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarStates_State",
                table: "CarStates",
                column: "State",
                unique: true,
                filter: "[State] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientTypes_Type",
                table: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_CarTypes_Type",
                table: "CarTypes");

            migrationBuilder.DropIndex(
                name: "IX_CarStates_State",
                table: "CarStates");
        }
    }
}
