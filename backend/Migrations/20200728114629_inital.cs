using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<string>(nullable: true),
                    firstPlayer = table.Column<string>(nullable: true),
                    currentTurn = table.Column<string>(nullable: true),
                    gameState = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<string>(nullable: true),
                    player = table.Column<string>(nullable: true),
                    xPosition = table.Column<int>(nullable: false),
                    yPosition = table.Column<int>(nullable: false),
                    gameId = table.Column<int>(nullable: false),
                    login = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
