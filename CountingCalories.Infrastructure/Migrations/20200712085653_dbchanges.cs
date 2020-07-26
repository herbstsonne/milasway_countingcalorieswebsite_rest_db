using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class dbchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CaloriesPer100g = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodInDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodInDayId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    FoodName = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    FoodPerDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodEntries_FoodInDays_FoodPerDayId",
                        column: x => x.FoodPerDayId,
                        principalTable: "FoodInDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntries_FoodPerDayId",
                table: "FoodEntries",
                column: "FoodPerDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "FoodEntries");

            migrationBuilder.DropTable(
                name: "FoodInDays");
        }
    }
}
