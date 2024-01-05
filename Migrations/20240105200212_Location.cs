using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWeb.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_LocationID",
                table: "Menu",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Location_LocationID",
                table: "Menu",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Location_LocationID",
                table: "Menu");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Menu_LocationID",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Menu");
        }
    }
}
