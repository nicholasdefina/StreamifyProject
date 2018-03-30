using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace streamify.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Playlists_PlaylistId",
                table: "Music");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Music",
                table: "Music");

            migrationBuilder.RenameTable(
                name: "Music",
                newName: "Musics");

            migrationBuilder.RenameIndex(
                name: "IX_Music_PlaylistId",
                table: "Musics",
                newName: "IX_Musics_PlaylistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musics",
                table: "Musics",
                column: "MusicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Playlists_PlaylistId",
                table: "Musics",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Playlists_PlaylistId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musics",
                table: "Musics");

            migrationBuilder.RenameTable(
                name: "Musics",
                newName: "Music");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_PlaylistId",
                table: "Music",
                newName: "IX_Music_PlaylistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Music",
                table: "Music",
                column: "MusicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Playlists_PlaylistId",
                table: "Music",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
