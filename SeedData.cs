using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace VideoGameApp.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Developers
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name", "Country" },
                values: new object[,]
                {
                    { 1, "Developer 1", "Country 1" },
                    { 2, "Developer 2", "Country 2" }
                });

            // Seed VideoGames
            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Title", "Genre", "Price", "Description", "ReleaseDate", "DeveloperId" },
                values: new object[,]
                {
                    { 1, "Game 1", "Genre 1", 29.99m, "Description 1", DateTime.Now, 1 },
                    { 2, "Game 2", "Genre 2", 39.99m, "Description 2", DateTime.Now, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove VideoGames
            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 2);

            // Remove Developers
            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

