using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWeb.Migrations
{
    public partial class Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationID",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reservation",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    ReservationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reservation_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ReservationID",
                table: "Menu",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientID",
                table: "Reservation",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LocationID",
                table: "Reservation",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Reservation_ReservationID",
                table: "Menu",
                column: "ReservationID",
                principalTable: "Reservation",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Reservation_ReservationID",
                table: "Menu");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ReservationID",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Reservation",
                table: "Location");
        }
    }
}
