using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class DBCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(maxLength: 45, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PricePerHour = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(maxLength: 45, nullable: true),
                    Year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarTypes_Type",
                        column: x => x.Type,
                        principalTable: "CarTypes",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 45, nullable: false),
                    FirstName = table.Column<string>(maxLength: 45, nullable: false),
                    SecondName = table.Column<string>(maxLength: 45, nullable: false),
                    Adress = table.Column<string>(maxLength: 45, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 45, nullable: true),
                    TypeOfClient = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientTypes_TypeOfClient",
                        column: x => x.TypeOfClient,
                        principalTable: "ClientTypes",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarHires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CarState = table.Column<string>(maxLength: 45, nullable: false),
                    Discount = table.Column<decimal>(nullable: true),
                    Penalty = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarHires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarHires_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarHires_CarStates_CarState",
                        column: x => x.CarState,
                        principalTable: "CarStates",
                        principalColumn: "State",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarHires_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarId",
                table: "CarHires",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarState",
                table: "CarHires",
                column: "CarState");

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_ClientId",
                table: "CarHires",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Type",
                table: "Cars",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TypeOfClient",
                table: "Clients",
                column: "TypeOfClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarHires");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarStates");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropTable(
                name: "ClientTypes");
        }
    }
}
