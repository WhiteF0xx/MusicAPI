using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicAPIV1.Migrations
{
    /// <inheritdoc />
    public partial class groupChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GenreTBL",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 100, "Heavy metal" },
                    { 101, "Hard Rock" },
                    { 102, "Punk Rock" },
                    { 103, "Symphonic rock" },
                    { 104, "Blues-Rock" },
                    { 105, "Rock & Roll" },
                    { 106, "Rockabilly " }
                });

            migrationBuilder.UpdateData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1008,
                column: "songURL",
                value: "https://www.youtube.com/watch?v=K8C-DP18-6g");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GenreTBL",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "GenreTBL",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "GenreTBL",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "GenreTBL",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "GenreTBL",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "GenreTBL",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "GenreTBL",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.UpdateData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1008,
                column: "songURL",
                value: " https://www.youtube.com/watch?v=K8C-DP18-6g");
        }
    }
}
