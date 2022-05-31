using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovieApp.Data.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheaterAddress",
                table: "theaterModel");

            migrationBuilder.DropColumn(
                name: "TheaterMovies",
                table: "theaterModel");

            migrationBuilder.RenameColumn(
                name: "TheaterName",
                table: "theaterModel",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "theaterModel",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "movieShowTimes",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieShowTimes", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_movieShowTimes_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieShowTimes_theaterModel_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theaterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimes_MovieId",
                table: "movieShowTimes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimes_TheatreId",
                table: "movieShowTimes",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieShowTimes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "theaterModel",
                newName: "TheaterName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "theaterModel",
                newName: "TheaterId");

            migrationBuilder.AddColumn<string>(
                name: "TheaterAddress",
                table: "theaterModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TheaterMovies",
                table: "theaterModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
