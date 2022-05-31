using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovieApp.Data.Migrations
{
    public partial class addingthetaer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "theaterModel",
                columns: table => new
                {
                    TheaterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheaterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterMovies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theaterModel", x => x.TheaterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "theaterModel");
        }
    }
}
