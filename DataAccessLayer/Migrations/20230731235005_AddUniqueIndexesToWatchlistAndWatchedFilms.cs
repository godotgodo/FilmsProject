using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddUniqueIndexesToWatchlistAndWatchedFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // WatchedFilms tablosuna birleşik indeks oluşturma
            migrationBuilder.CreateIndex(
                name: "IX_WatchedFilms_UserId_FilmId",
                table: "WatchedFilms",
                columns: new[] { "UserId", "FilmId" },
                unique: true);

            // Watchlist tablosuna birleşik indeks oluşturma
            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId_FilmId",
                table: "Watchlists",
                columns: new[] { "UserId", "FilmId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // WatchedFilms tablosundaki indeksi geri al
            migrationBuilder.DropIndex(
                name: "IX_WatchedFilms_UserId_FilmId",
                table: "WatchedFilms");

            // Watchlist tablosundaki indeksi geri al
            migrationBuilder.DropIndex(
                name: "IX_Watchlists_UserId_FilmId",
                table: "Watchlists");
        }
    }
}
