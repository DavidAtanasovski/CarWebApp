using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWebData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductLabel = table.Column<string>(nullable: false),
                    ModelName = table.Column<string>(nullable: false),
                    Seats = table.Column<string>(nullable: false),
                    Wheels = table.Column<string>(nullable: false),
                    EngineLabel = table.Column<string>(nullable: false),
                    MaxEngPower = table.Column<int>(nullable: false),
                    MaxTorqPower = table.Column<int>(nullable: false),
                    FuelType = table.Column<string>(nullable: false),
                    OverallLenght = table.Column<int>(nullable: false),
                    OverallWidth = table.Column<int>(nullable: false),
                    OverallHeight = table.Column<int>(nullable: false),
                    LightestCurbWeight = table.Column<int>(nullable: false),
                    HeaviestCurbWeight = table.Column<int>(nullable: false),
                    Tires = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
