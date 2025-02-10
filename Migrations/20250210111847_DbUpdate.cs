using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace VideoGameApp.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ensure the developer is inserted before the video games
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "Poland", "CD Projekt Red" });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Description", "DeveloperId", "Genre", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "An open-world RPG set in a stunning fantasy universe filled with meaningful choices and impactful consequences.", 1, "RPG", 39.99m, new DateTime(2015, 5, 19), "The Witcher 3" },
                    { 2, "A narrative-driven, open-world RPG set in the vibrant and dangerous metropolis of Night City.", 1, "RPG", 59.99m, new DateTime(2020, 12, 10), "Cyberpunk 2077" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
