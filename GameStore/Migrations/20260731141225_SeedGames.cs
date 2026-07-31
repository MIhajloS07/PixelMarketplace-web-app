using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class SeedGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Author", "Price", "Title", "releaseDate" },
                values: new object[,]
                {
                    { 1, "Bungie", 50m, "Halo", new DateTime(2001, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Valve", 20m, "Half-Life", new DateTime(1998, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "CD Projekt", 30m, "The Witcher 3", new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
