using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWeb.Migrations
{
    public partial class DishCuisine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chef",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "ChefID",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cuisine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DishCuisine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    CuisineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCuisine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DishCuisine_Cuisine_CuisineID",
                        column: x => x.CuisineID,
                        principalTable: "Cuisine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishCuisine_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ChefID",
                table: "Menu",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_DishCuisine_CuisineID",
                table: "DishCuisine",
                column: "CuisineID");

            migrationBuilder.CreateIndex(
                name: "IX_DishCuisine_MenuID",
                table: "DishCuisine",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Chef_ChefID",
                table: "Menu",
                column: "ChefID",
                principalTable: "Chef",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Chef_ChefID",
                table: "Menu");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropTable(
                name: "DishCuisine");

            migrationBuilder.DropTable(
                name: "Cuisine");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ChefID",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ChefID",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "Chef",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
