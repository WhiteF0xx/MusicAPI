using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicAPIV1.Migrations
{
    /// <inheritdoc />
    public partial class feedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupsTBL",
                columns: new[] { "Id", "Description", "GenreID", "Groupname" },
                values: new object[,]
                {
                    { 1000, "Hard Rock", 101, "Deep Purple" },
                    { 1001, "Hard Rock", 101, "Rainbow" },
                    { 1002, "Heavy Metal", 100, "Accept" },
                    { 1003, "Heavy Metal", 100, "Helloween" },
                    { 1004, "Heavy Metal", 103, "Nightwish" },
                    { 1005, "Heavy Metal", 101, "AC/DC" },
                    { 1006, "Heavy Metal", 100, "Metallica" }
                });

            migrationBuilder.InsertData(
                table: "SongsTBL",
                columns: new[] { "Id", "GroupId", "SongName", "songURL" },
                values: new object[,]
                {
                    { 1000, 1000, "Child in Time", "https://www.youtube.com/watch?v=OorZcOzNcgE" },
                    { 1001, 1000, "Smoke on the water", "https://www.youtube.com/watch?v=zUwEIt9ez7M" },
                    { 1002, 1000, "Highway Star", "https://www.youtube.com/watch?v=Wr9ie2J2690" },
                    { 1003, 1001, "Temple of the King", "https://www.youtube.com/watch?v=B7nKzCRL_oo" },
                    { 1004, 1001, "Stargazer", "https://www.youtube.com/watch?v=YmJIccPWnEk" },
                    { 1005, 1004, "The Phantom Of The Opera", "https://www.youtube.com/watch?v=tL25rbnvM4o" },
                    { 1006, 1004, "Wish I Had An Angel", "https://www.youtube.com/watch?v=wEERFBI9eCg" },
                    { 1007, 1002, "Can't Stand the Night", "https://www.youtube.com/watch?v=cnwr0xsAMTo" },
                    { 1008, 1002, "Princess of the Dawn", " https://www.youtube.com/watch?v=K8C-DP18-6g" },
                    { 1009, 1006, "Master of Puppets", "https://www.youtube.com/watch?v=E0ozmU9cJDg" },
                    { 1010, 1006, "The Unforgiven", "https://www.youtube.com/watch?v=DDGhKS6bSAE" },
                    { 1011, 1006, "Enter Sandman", "https://www.youtube.com/watch?v=CD-E-LDc384" },
                    { 1012, 1003, "I Want Out", "https://www.youtube.com/watch?v=FjV8SHjHvHk" },
                    { 1013, 1003, "A Tale That Wasn't Right", "https://www.youtube.com/watch?v=wbGjYQsx3c8" },
                    { 1016, 1005, "T.N.T.", "https://www.youtube.com/watch?v=NhsK5WExrnE" },
                    { 1017, 1005, "Thunderstruck", "https://www.youtube.com/watch?v=v2AC41dglnM" },
                    { 1018, 1005, "Highway to Hell", "https://www.youtube.com/watch?v=UCskpE9KGQU" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "SongsTBL",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "GroupsTBL",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "GroupsTBL",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "GroupsTBL",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "GroupsTBL",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "GroupsTBL",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "GroupsTBL",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "GroupsTBL",
                keyColumn: "Id",
                keyValue: 1006);
        }
    }
}
