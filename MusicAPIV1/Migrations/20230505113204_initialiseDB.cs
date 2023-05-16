using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPIV1.Migrations
{
    /// <inheritdoc />
    public partial class initialiseDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenreTBL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupsTBL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Groupname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsTBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongsTBL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    SongName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    songURL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsTBL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongsTBL_GroupsTBL_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupsTBL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongsTBL_GroupId",
                table: "SongsTBL",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreTBL");

            migrationBuilder.DropTable(
                name: "SongsTBL");

            migrationBuilder.DropTable(
                name: "GroupsTBL");
        }
    }
}
